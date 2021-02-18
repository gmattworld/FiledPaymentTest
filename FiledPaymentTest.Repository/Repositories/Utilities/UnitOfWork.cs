using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FiledPaymentTest.Repository.IRepositories;
using FiledPaymentTest.Repository.Repositories.EF;

namespace FiledPaymentTest.Repository.Repositories.Utilities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FPTDBContext _context;

        public UnitOfWork(FPTDBContext context)
        {
            _context = context;
            PaymentProcesses = new PaymentProcessRepository(_context);
        }

        public IPaymentProcessRepository PaymentProcesses { get; private set; }



        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}