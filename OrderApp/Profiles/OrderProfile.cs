using AutoMapper;
using OrderApp.Models;
using OrderApp.Models.Dto;

namespace OrderApp.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CustomerOrderDto, CustomerOrderModel>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("dd/MM/yy")))
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalCost.ToString("G29")));
        }
    }
}
