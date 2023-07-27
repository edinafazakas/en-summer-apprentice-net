using Microsoft.EntityFrameworkCore;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class VenueRepository : IVenueRepository
    {


        private readonly TicketManagementContext _dbContext;

        public VenueRepository()
        {
            _dbContext = new TicketManagementContext();
        }

        public async Task<Venue> GetById(int? id)
        {
            var venue = _dbContext.Venues.Where(v => v.VenueId == id).FirstOrDefault();
            return venue;
        }
    }
}
