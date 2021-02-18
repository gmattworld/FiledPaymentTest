using FiledPaymentTest.Service.PaymentGateways;
using FluentAssertions;
using Xunit;

namespace FiledPaymentTest.UnitTest.ServiceTest
{
    public class PremiumPaymentTest
    {
        [Fact]
        public void ExpensivePayment_MakePayment_ReturnBool()
        {
            // Arrange
            var retval = new PaymentGatewayFactory().PremiumPayments.MakePayment();

            // Assert
            retval.GetType().Should().BeSameAs(typeof(bool));
        }
    }
}
