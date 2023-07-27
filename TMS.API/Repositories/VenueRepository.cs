using Microsoft.EntityFrameworkCore;
using TMS.API.Exceptions;
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
            var venue = await _dbContext.Venues.Where(v => v.VenueId == id).FirstOrDefaultAsync();

            if (venue == null)
                throw new EntityNotFoundException(id, nameof(Venue));
            return venue;
        }
    }
}
