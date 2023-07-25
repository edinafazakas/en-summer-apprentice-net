using Microsoft.Extensions.Logging;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TicketManagementContext();
        }
        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var @event = _dbContext.Events.FirstOrDefault(e => e.EventId == id);

            if (@event == null)
            {
                return 0;
            }

            _dbContext.Events.Remove(@event);
            _dbContext.SaveChanges();

            return id;
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;
            return events;
        }

        public Event GetById(int id)
        {
            var @event = _dbContext.Events.Where(e => e.EventId == id).FirstOrDefault();
            return @event;
        }

        public void Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
