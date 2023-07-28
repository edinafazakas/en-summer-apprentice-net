using Microsoft.EntityFrameworkCore;
using TMS.API.Exceptions;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementContext _dbContext;

        public TicketCategoryRepository()
        {
            _dbContext = new TicketManagementContext();
        }
        public async Task<TicketCategory> GetById(int? id)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(o => o.TicketCategoryId == id).FirstOrDefaultAsync();

            if (ticketCategory == null)
                throw new EntityNotFoundException(id, nameof(TicketCategory));

            return ticketCategory;
        }
    }
}
