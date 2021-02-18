using FiledPaymentTest.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiledPaymentTest.Repository.Repositories.EF
{
    public class FPTDBContext : DbContext
    {
        public FPTDBContext(DbContextOptions<FPTDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Add PaymentProcess dataset to DBContext
        /// </summary>
        public DbSet<PaymentProcess> PaymentProcesses { get; set; }
    }
}