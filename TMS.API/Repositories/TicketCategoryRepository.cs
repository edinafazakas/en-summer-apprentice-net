using Microsoft.EntityFrameworkCore;
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

        public async Task<TicketCategory> GetByDescription(string description)
        {
            var ticketCategory = _dbContext.TicketCategories.Where(t => t.Description == description).FirstOrDefault();
            return ticketCategory;
        }

        public async Task<TicketCategory> GetById(int? id)
        {
            var ticketCategory = _dbContext.TicketCategories.Where(t => t.TicketCategoryId == id).FirstOrDefault();
            return ticketCategory;
        }
    }
}
