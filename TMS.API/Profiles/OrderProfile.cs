using TMS.API.Models.Dto;
using TMS.API.Models;
using AutoMapper;

namespace TMS.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
            CreateMap<Order, OrderAddDto>().ReverseMap();
        }
    }
}
