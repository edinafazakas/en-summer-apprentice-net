using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TMS.API.Exceptions;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;
using TMS.API.Services;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
           
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var dtoEvents = _eventService.GetAll();
            return Ok(dtoEvents);
        }


        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var eventDto = await _eventService.GetById(id);
            if (eventDto == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return Ok(eventDto);

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedEvent = await _eventService.GetById(id);
            if (deletedEvent == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }
            _eventService.Delete(id);
            return Ok(deletedEvent);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventService.Patch(eventPatch);
            return Ok(eventEntity);

        }

        [HttpPost]
        public ActionResult<int> AddEvent(EventAddDto eventAddDto)
        {
            var eventId =  _eventService.AddEvent(eventAddDto);
            return Created("", "Event with id " + eventId + " created successfully!");
        }

    }
}
