using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventTypeRepository _eventTypeRepository;
        private readonly IVenueRepository _venueRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EventController(IEventRepository eventRepository, IMapper mapper, IEventTypeRepository eventTypeRepository, IVenueRepository venueRepository, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _eventTypeRepository = eventTypeRepository;
            _venueRepository = venueRepository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
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

            return Ok(dtoEvents);
        }


        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var @event = await _eventRepository.GetById(id);
            var eventDto = _mapper.Map<EventDto>(@event);

            return Ok(eventDto);

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedEvent = await _eventRepository.GetById(id);
            _eventRepository.Delete(deletedEvent);
            return Ok(deletedEvent);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
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
            return Ok(eventEntity);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEvent(EventAddDto eventAddDto)
        {
            var eventType = await _eventTypeRepository.GetById(eventAddDto.EventTypeId);
            var venue = await _venueRepository.GetById(eventAddDto.VenueId);

            var @event = new Event()
            {
                EventId = eventAddDto.EventId,
                Description = eventAddDto.Description,
                EventTypeId = eventAddDto.EventTypeId,
                Name = eventAddDto.Name,
                StartDate = eventAddDto.StartDate,
                EndDate = eventAddDto.EndDate,
                VenueId = eventAddDto.VenueId,
            };

            _eventRepository.Add(@event);

            return Ok(@event.EventId);
        }

    }
}
