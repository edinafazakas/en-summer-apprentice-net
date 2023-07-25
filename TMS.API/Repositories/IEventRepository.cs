using Microsoft.Extensions.Logging;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(int id);
        int Add(Event @event);

        void Update(Event @event);

        int Delete(int id);
    }
}
