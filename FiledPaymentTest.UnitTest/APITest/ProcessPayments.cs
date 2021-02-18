using System;
using FiledPaymentTest.Core.Models;
using FiledPaymentTest.Core.Validators;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace FiledPaymentTest.UnitTest.APITest
{
    public class ProcessPayments
    {
        [Theory]
        [InlineData(0, "Golden User", "12313121", "2020-09-11", "1212")]
        [InlineData(10, "", "12313121", "2020-09-11", "121")]
        [InlineData(-20, "Golden", "12313121", "2020-01-11", "12")]
        [InlineData(60, "User", "12313121", "2020-12-11", "10")]
        [InlineData(-10, "Golden User", "12313121", "2020-09-01", "121")]
        [InlineData(90, "Golden User", "12313234345345434121", "2020-12-11", "112")]
        public void ProcessPayments_Validator_Invalid(decimal amount, string cardHolder, string creditCard, DateTime exp, string sec)
        {
            // Arrange
            PaymentProcessModel model = new PaymentProcessModel()
            {
                Amount = amount,
                CardHolder = cardHolder,
                CreditCardNumber = creditCard,
                ExpirationDate = exp,
                SecurityCode = sec
            };

            // Act
            PaymentProcessValidator _validator = new PaymentProcessValidator();
            ValidationResult result = _validator.Validate(model);

            // Assert
            result.IsValid.Should().BeFalse();
        }


        [Theory]
        [InlineData(50, "Golden User", "123456789012345", "2022-09-11", "222")]
        [InlineData(10, "Test User", "123456789012345", "2023-09-11", "121")]
        public void ProcessPayments_Validator_Valid(decimal amount, string cardHolder, string creditCard, DateTime exp, string sec)
        {
            // Arrange
            PaymentProcessModel model = new PaymentProcessModel()
            {
                Amount = amount,
                CardHolder = cardHolder,
                CreditCardNumber = creditCard,
                ExpirationDate = exp,
                SecurityCode = sec
            };

            // Act
            PaymentProcessValidator _validator = new PaymentProcessValidator();
            ValidationResult result = _validator.Validate(model);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
