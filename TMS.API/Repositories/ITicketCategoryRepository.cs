using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface ITicketCategoryRepository
    { 
        Task<TicketCategory> GetById(int? id);

        Task<TicketCategory> GetByDescription(string description);

    }
}
