using AutoMapper;
using TMS.API.Models;
using TMS.API.Models.Dto;

namespace TMS.API.Profiles
{
    public class EventProfile : Profile
    {

        public EventProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();
            CreateMap<Event, EventAddDto>().ReverseMap();
        }
    }
}
