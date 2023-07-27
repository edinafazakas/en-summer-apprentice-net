using Microsoft.EntityFrameworkCore;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface IVenueRepository
    {
        Task<Venue> GetById(int? id);
    }
}
