using Microsoft.Extensions.Logging;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(int id);
        int Add(Event @event);

        void Update(Event @event);

        void Delete(Event @event);
    }
}
