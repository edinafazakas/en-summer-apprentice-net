using TMS.API.Models;

namespace TMS.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int? id);
    }
}
