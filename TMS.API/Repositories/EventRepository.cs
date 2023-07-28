using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.API.Exceptions;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementContext _dbContext;
        private readonly ILogger _logger;

        public EventRepository(ILogger<EventRepository> logger)
        {
            _dbContext = new TicketManagementContext();
            _logger = logger;

        }
        public int Add(Event @event)
        {
            _dbContext.Events.Add(@event);
            _dbContext.SaveChanges();
            return @event.EventId;
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }


        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(o => o.EventId == id).FirstOrDefaultAsync();

            if (@event == null)
            {
                _logger.LogError("Object not found");
                throw new EntityNotFoundException(id, nameof(Event));
            }
            return @event;
        }


        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
