using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiledPaymentTest.Core.Entities;
using FiledPaymentTest.Core.Enums;
using FiledPaymentTest.Repository.IRepositories;
using FiledPaymentTest.Repository.Repositories.EF;
using FiledPaymentTest.Repository.Repositories.Utilities;
using FiledPaymentTest.Service.PaymentGateways;
using Microsoft.EntityFrameworkCore;

namespace FiledPaymentTest.Repository.Repositories
{
    public class PaymentProcessRepository : BaseRepository<PaymentProcess, string>, IPaymentProcessRepository
    {
        protected readonly FPTDBContext _context;

        public PaymentProcessRepository(FPTDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PaymentProcesses.AnyAsync(e => e.Id.Equals(id));
        }

        public async Task<List<PaymentProcess>> GetPendingPayments()
        {
            return await _context.PaymentProcesses.Where(a => a.Status.Equals(PaymentStatus.PENDING)).ToListAsync();
        }

        public async Task ProcessPendingPayments()
        {
            IList<PaymentProcess> pendingPayment = await GetPendingPayments();
            IPaymentGatewayFactory _paymentFactory = new PaymentGatewayFactory();


            foreach (PaymentProcess _payment in pendingPayment)
            {
                // Payment Condition
                if (_payment.Amount > 500)
                {
                    // IPremium Payment Gateway
                    if (_paymentFactory.PremiumPayments.MakePayment())
                    {
                        _payment.Status = PaymentStatus.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.Status = PaymentStatus.PENDING;
                        _payment.Tries = _payment.Tries + 1;

                        if (_payment.Tries == 3)
                        {
                            _payment.Status = PaymentStatus.FAILED;
                        }
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }

                if (_payment.Amount < 21)
                {
                    // ICheap Payment Gateway
                    if (_paymentFactory.CheapPayments.MakePayment())
                    {
                        _payment.Status = PaymentStatus.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.Status = PaymentStatus.FAILED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }

                if (_payment.Amount <= 500)
                {
                    // Check Expensive payment availability
                    if (_paymentFactory.ExpensivePayments.CheckAvailability() && _paymentFactory.ExpensivePayments.MakePayment())
                    {
                        _payment.Status = PaymentStatus.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    // Try ICheap Payment Gateway
                    else if (_paymentFactory.CheapPayments.MakePayment())
                    {
                        _payment.Status = PaymentStatus.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.Status = PaymentStatus.FAILED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }                
            }
        }
    }
}
