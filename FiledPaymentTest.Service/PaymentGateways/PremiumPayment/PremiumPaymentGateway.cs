using System;

namespace FiledPaymentTest.Service.PaymentGateways.PremiumPayment
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public bool MakePayment() => (new Random().Next(0, 1)) == 1;
    }
}
