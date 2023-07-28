using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.API.Controllers;
using TMS.API.Models.Dto;
using TMS.API.Models;
using TMS.API.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace TMS.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;

        }

        public List<EventDto> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                Description = e.Description,
                Name = e.Name,
                EventTypeId = e.EventTypeId,
                VenueId = e.VenueId
            });

            return dtoEvents.ToList();
        }

        public async Task<EventDto> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);
            var eventDto = _mapper.Map<EventDto>(@event);

            return eventDto;

        }


        public async void Delete(int id)
        {
            var deletedEvent = await _eventRepository.GetById(id);
            _eventRepository.Delete(deletedEvent);
        }


        public async Task<Event> Patch(EventPatchDto eventPatch)
        {

            if (eventPatch == null)
            {
                throw new ArgumentNullException(nameof(eventPatch));
            }

            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);

            if (!eventPatch.EventName.IsNullOrEmpty())
                eventEntity.Name = eventPatch.EventName;

            if (!eventPatch.EventDescription.IsNullOrEmpty())
                eventEntity.Description = eventPatch.EventDescription;

            _eventRepository.Update(eventEntity);
            return eventEntity;
        }


        public int AddEvent(EventAddDto eventAddDto)
        {
            var @event = _mapper.Map<Event>(eventAddDto);
            _eventRepository.Add(@event);
            return @event.EventId;
        }
    }
}
