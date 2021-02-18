using System;

namespace FiledPaymentTest.Service.PaymentGateways.ExpensivePayment
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public bool MakePayment() => (new Random().Next(0, 1)) == 1;
        public bool CheckAvailability() => (new Random().Next(0, 1)) == 1;
    }
}
