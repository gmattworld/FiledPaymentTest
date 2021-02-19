using FiledPaymentTest.Core.Entities;
using FiledPaymentTest.Core.Models;
using FiledPaymentTest.Core.Models.ModelExt;

namespace FiledPaymentTest.Mappers
{
    public class PaymentProcessMap : AutoMapper.Profile
    {
        public PaymentProcessMap()
        {
            CreateMap<PaymentProcess, PaymentProcessModel>().ReverseMap();
            CreateMap<PaymentProcess, PaymentProcessExtModel>().ReverseMap();

            // For member can be used for custom mapping
        }
    }
}
