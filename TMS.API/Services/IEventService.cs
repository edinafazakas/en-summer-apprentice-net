using TMS.API.Models;
using TMS.API.Models.Dto;

namespace TMS.API.Services
{
    public interface IEventService
    {
        public List<EventDto> GetAll();
        Task<EventDto> GetById(int id);
        Task<Event> Patch(EventPatchDto eventPatch);
        int AddEvent(EventAddDto eventAddDto);
        void Delete(int id);
    }
}
