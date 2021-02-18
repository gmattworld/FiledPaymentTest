using System.Threading.Tasks;
using FiledPaymentTest.Core.Entities;
using FiledPaymentTest.Repository.IRepositories.Utilities;

namespace FiledPaymentTest.Repository.IRepositories
{
    public interface IPaymentProcessRepository : IBaseRepository<PaymentProcess, string>
    {
        Task<bool> ExistsAsync(int id);
        Task ProcessPendingPayments();
    }
}
