using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.API.Models;

namespace TMS.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketManagementContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TicketManagementContext();
        }
        public int Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order.OrderId; 
        }

        public void Delete(Order order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order =  _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            return order;
        }

        public void Update(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
