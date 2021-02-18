using FiledPaymentTest.Core.Enums;

namespace FiledPaymentTest.Core.Models.ModelExt
{
    public class PaymentProcessExtModel : PaymentProcessModel
    {
        public string Id { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
