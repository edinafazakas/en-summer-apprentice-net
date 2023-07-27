using Microsoft.EntityFrameworkCore;
using System;
using TMS.API.Exceptions;
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
            var customer = await _dbContext.Customers.Where(t => t.CustomerId == id).FirstOrDefaultAsync();
            if (customer == null)
                throw new EntityNotFoundException(id, nameof(Customer));
            return customer;
        }
    }
}
