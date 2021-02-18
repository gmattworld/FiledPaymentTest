using FiledPaymentTest.Service.PaymentGateways;
using FluentAssertions;
using Xunit;

namespace FiledPaymentTest.UnitTest.ServiceTest
{
    public class ExpensivePaymentTest
    {
        [Fact]
        public void ExpensivePayment_MakePayment_ReturnBool()
        {
            // Arrange
            var retval = new PaymentGatewayFactory().ExpensivePayments.MakePayment();

            // Assert
            retval.GetType().Should().BeSameAs(typeof(bool));
        }

        [Fact]
        public void ExpensivePayment_CheckValidity_ReturnBool()
        {
            // Arrange
            var retval = new PaymentGatewayFactory().ExpensivePayments.CheckAvailability();

            // Assert
            retval.GetType().Should().BeSameAs(typeof(bool));
        }
    }
}
