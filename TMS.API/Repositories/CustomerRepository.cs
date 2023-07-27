using Microsoft.EntityFrameworkCore;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TicketManagementContext _dbContext;

        public CustomerRepository()
        {
            _dbContext = new TicketManagementContext();
        }
        public async Task<Customer> GetById(int? id)
        {
            var customer = _dbContext.Customers.Where(t => t.CustomerId == id).FirstOrDefault();
            return customer;
        }
    }
}
