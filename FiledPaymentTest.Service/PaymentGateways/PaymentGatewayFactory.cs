using FiledPaymentTest.Service.PaymentGateways.CheapPayment;
using FiledPaymentTest.Service.PaymentGateways.ExpensivePayment;
using FiledPaymentTest.Service.PaymentGateways.PremiumPayment;

namespace FiledPaymentTest.Service.PaymentGateways
{
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        public PaymentGatewayFactory()
        {
            CheapPayments = new CheapPaymentGateway();
            ExpensivePayments = new ExpensivePaymentGateway();
            PremiumPayments = new PremiumPaymentGateway();
        }

        public ICheapPaymentGateway CheapPayments { get; private set; }

        public IExpensivePaymentGateway ExpensivePayments { get; private set; }

        public IPremiumPaymentGateway PremiumPayments { get; private set; }
    }
}