using Microsoft.EntityFrameworkCore;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly TicketManagementContext _dbContext;

        public EventTypeRepository()
        {
            _dbContext = new TicketManagementContext();
        }
        public async Task<EventType> GetById(int? id)
        {
            var eventType = _dbContext.EventTypes.Where(e => e.EventTypeId == id).FirstOrDefault();

            return eventType;
        }

        public async Task<EventType> GetByName(string name)
        {
            var eventType = _dbContext.EventTypes.Where(e => e.Name == name).FirstOrDefault();

            return eventType;
        }
    }
}
