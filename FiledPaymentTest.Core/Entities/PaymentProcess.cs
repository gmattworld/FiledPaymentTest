using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FiledPaymentTest.Core.Enums;

namespace FiledPaymentTest.Core.Entities
{
    public class PaymentProcess : BaseEntity<string>
    {
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string CreditCardNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }


        public PaymentStatus Status { get; set; }
        public int Tries { get; set; }
    }
}
