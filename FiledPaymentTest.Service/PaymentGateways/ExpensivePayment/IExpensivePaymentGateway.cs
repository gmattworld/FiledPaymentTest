namespace FiledPaymentTest.Service.PaymentGateways.ExpensivePayment
{
    public interface IExpensivePaymentGateway
    {
        bool MakePayment();
        bool CheckAvailability();
    }
}
