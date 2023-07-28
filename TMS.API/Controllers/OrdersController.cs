using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Repositories;
using TMS.API.Services;

namespace TMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var dtoOrders = _orderService.GetAll();
            return Ok(dtoOrders);
        }


        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var orderDto = await _orderService.GetById(id);
            return Ok(orderDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedOrder = await _orderService.GetById(id);
            _orderService.Delete(id);
            return Ok(deletedOrder);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatchDto)
        {
            var orderEntity = await _orderService.Patch(orderPatchDto);
            return Ok(orderEntity);
        }


        [HttpPost]
        public async Task<ActionResult<int>> AddOrder(OrderAddDto orderDto)
        {
            var orderId =  await _orderService.AddOrder(orderDto);
            return Ok(orderId);
        }

    }
}
