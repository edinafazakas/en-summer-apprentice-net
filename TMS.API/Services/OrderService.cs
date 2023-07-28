using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;

namespace TMS.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;

        }

        public List<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(o => new OrderDto()
            {
                OrderId = o.OrderId,
                OrderedAt = o.OrderedAt,
                TotalPrice = o.TotalPrice,
                NumberOfTickets = o.NumberOfTickets
            });

            return dtoOrders.ToList();
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;

        }


        public async void Delete(int id)
        {
            var deletedOrder = await _orderRepository.GetById(id);
            _orderRepository.Delete(deletedOrder);
        }


        public async Task<Order> Patch(OrderPatchDto orderPatch)
        {

            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            var ticketCategoryEntity = await _ticketCategoryRepository.GetById(orderEntity.TicketCategoryId);

            if (orderPatch.NumberOfTickets != 0)
                orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;

            orderEntity.TotalPrice = orderPatch.NumberOfTickets * ticketCategoryEntity.Price;
            _orderRepository.Update(orderEntity);
            return orderEntity;
        }


        public async Task<int> AddOrder(OrderAddDto orderAddDto)
        {
            var order = _mapper.Map<Order>(orderAddDto);
            var ticketCategory =  await _ticketCategoryRepository.GetById(orderAddDto.TicketCategoryId);
            order.TotalPrice = orderAddDto.NumberOfTickets * ticketCategory.Price;

            _orderRepository.Add(order);
            return order.OrderId;
        }
    }
}
