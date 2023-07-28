using TMS.API.Models.Dto;
using TMS.API.Models;

namespace TMS.API.Services
{
    public interface IOrderService
    {
        public List<OrderDto> GetAll();
        Task<OrderDto> GetById(int id);
        Task<Order> Patch(OrderPatchDto orderPatchDto);
        Task<int> AddOrder(OrderAddDto orderAddDto);
        void Delete(int id);
    }
}
