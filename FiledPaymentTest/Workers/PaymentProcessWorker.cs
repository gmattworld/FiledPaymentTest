using System;
using System.Threading;
using System.Threading.Tasks;
using FiledPaymentTest.Repository;
using FiledPaymentTest.Repository.Repositories.EF;
using FiledPaymentTest.Repository.Repositories.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FiledPaymentTest.Workers
{
    public class PaymentProcessWorker : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public PaymentProcessWorker(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() => PaymentProcessService(stoppingToken));
        }

        private async void PaymentProcessService(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<FPTDBContext>();
                    _ = new UnitOfWork(dbContext).PaymentProcesses.ProcessPendingPayments();
                }
                // Payment process happens here
                
                await Task.Delay((3 * 60000), stoppingToken); //runs every 3 minutes
            }
        }
    }
}
