using FiledPaymentTest.Service.PaymentGateways.CheapPayment;
using FiledPaymentTest.Service.PaymentGateways.ExpensivePayment;
using FiledPaymentTest.Service.PaymentGateways.PremiumPayment;

namespace FiledPaymentTest.Service.PaymentGateways
{
    public interface IPaymentGatewayFactory
    {
        ICheapPaymentGateway CheapPayments { get; }
        IExpensivePaymentGateway ExpensivePayments { get; }
        IPremiumPaymentGateway PremiumPayments { get; }
    }
}
