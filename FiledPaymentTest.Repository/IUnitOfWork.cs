using System;
using System.Threading.Tasks;
using FiledPaymentTest.Repository.IRepositories;

namespace FiledPaymentTest.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentProcessRepository PaymentProcesses { get; }
        Task<int> CompleteAsync();
    }
}
