using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.API.Models.Dto;
using TMS.API.Repositories;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(o => new OrderDto()
            {
                OrderId = o.OrderId,
                OrderedAt = o.OrderedAt,
                TotalPrice = o.TotalPrice,
                NumberOfTickets = o.NumberOfTickets,
            });

            return Ok(dtoOrders);
        }


        [HttpGet]
        public ActionResult<OrderDto> GetById(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var dtoOrder = new OrderDto()
            {
                OrderId = order.OrderId,
                OrderedAt = order.OrderedAt,
                TotalPrice = order.TotalPrice,
                NumberOfTickets = order.NumberOfTickets,
            };

            return Ok(dtoOrder);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedOrderId = _orderRepository.Delete(id);

            if (deletedOrderId == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Order deleted successfully." });
        }
    }
}
