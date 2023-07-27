using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedOrder = await _orderRepository.GetById(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(deletedOrder);
            return Ok(deletedOrder);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatchDto)
        {
            var orderEntity = await _orderRepository.GetById(orderPatchDto.OrderId);
            var ticketCategoryEntity = await _ticketCategoryRepository.GetById(orderEntity.TicketCategoryId);
            if (orderEntity == null)
            {
                return NotFound();
            }

            if (orderPatchDto.NumberOfTickets != 0)
                orderEntity.NumberOfTickets = orderPatchDto.NumberOfTickets;

            orderEntity.TotalPrice = orderPatchDto.NumberOfTickets * ticketCategoryEntity.Price;
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }



        [HttpPost]
        public async Task<ActionResult<int>> AddOrder(OrderAddDto orderDto)
        {
            var ticketCategory = await _ticketCategoryRepository.GetById(orderDto.TicketCategoryId);
            if (ticketCategory == null)
            {
                return NotFound("Ticket category not found.");
            }

            var customer = await _customerRepository.GetById(orderDto.CustomerId);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            var order = new Order()
            {
                OrderId = orderDto.OrderId,
                OrderedAt = orderDto.OrderedAt,
                NumberOfTickets = orderDto.NumberOfTickets,
                CustomerId = orderDto.CustomerId,
                Customer = null, 
                TicketCategory = null, 
                TicketCategoryId = orderDto.TicketCategoryId,
                TotalPrice = orderDto.NumberOfTickets * ticketCategory.Price, 
            };

            _orderRepository.Add(order); 


            return Ok(order.OrderId); 
        }




    }
}
