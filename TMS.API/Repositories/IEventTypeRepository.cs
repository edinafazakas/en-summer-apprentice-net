using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IEventTypeRepository
    {

        Task<EventType> GetById(int? id);

        Task<EventType> GetByName(string name);


    }
}
