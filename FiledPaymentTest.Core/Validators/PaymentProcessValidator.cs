using System;
using FiledPaymentTest.Core.Models;
using FluentValidation;

namespace FiledPaymentTest.Core.Validators
{
    public class PaymentProcessValidator : AbstractValidator<PaymentProcessModel>
    {
        //- CreditCardNumber(mandatory, string, it should be a valid CCN)
        //- CardHolder: (mandatory, string)
        //- ExpirationDate(mandatory, DateTime, it cannot be in the past)
        //- SecurityCode(optional, string, 3 digits)
        //- Amount(mandatoy decimal, positive amount)
        public PaymentProcessValidator()
        {
            RuleFor(applicant => applicant.CreditCardNumber).NotNull().CreditCard();
            RuleFor(applicant => applicant.CardHolder).NotNull().MinimumLength(3).MaximumLength(99);
            RuleFor(applicant => applicant.ExpirationDate).GreaterThan(DateTime.Now);
            RuleFor(applicant => applicant.SecurityCode).NotNull().Length(3);
            RuleFor(applicant => applicant.Amount).GreaterThan(0).NotNull();
        }
    }
}
