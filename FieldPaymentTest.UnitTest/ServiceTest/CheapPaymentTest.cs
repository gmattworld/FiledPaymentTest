using FiledPaymentTest.Service.PaymentGateways;
using FluentAssertions;
using Xunit;

namespace FiledPaymentTest.UnitTest.ServiceTest
{
    public class CheapPaymentTest
    {
        [Fact]
        public void ExpensivePayment_MakePayment_ReturnBool()
        {
            // Arrange
            var retval = new PaymentGatewayFactory().CheapPayments.MakePayment();

            // Assert
            retval.GetType().Should().BeSameAs(typeof(bool));
        }
    }
}
