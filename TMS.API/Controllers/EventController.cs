using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                EventDescription = e.Description,
                EventName = e.Name,
                EventType = e.EventType?.Name ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });

            return Ok(dtoEvents);
        }


        [HttpGet]
        public ActionResult<EventDto> GetById(int id)
        {
            var @event = _eventRepository.GetById(id);

            if (@event == null)
            {
                return NotFound();
            }

            var dtoEvent = new EventDto()
            {
                EventId = @event.EventId,
                EventDescription = @event.Description,
                EventName = @event.Name,
                EventType = @event.EventType?.Name ?? string.Empty,
                Venue = @event.Venue?.Location ?? string.Empty
            };

            return Ok(dtoEvent);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedEventId = _eventRepository.Delete(id);

            if (deletedEventId == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Event deleted successfully." });
        }
    }
}
