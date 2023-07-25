using Microsoft.EntityFrameworkCore;
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
        public int Add(Order @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return 0;
            }

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return id;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public Order GetById(int id)
        {
            var order = _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            return order;
        }

        public void Update(Order @event)
        {
            throw new NotImplementedException();
        }
    }
}
