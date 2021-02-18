using System;

namespace FiledPaymentTest.Service.PaymentGateways.CheapPayment
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public bool MakePayment() => (new Random().Next(0, 1)) == 1;
    }
}
