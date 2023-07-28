/*using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.API.Controllers;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Services;
using Xunit;

public class OrdersControllerTests
{
    private Mock<IOrderService> mockOrderService;
    private OrdersController ordersController;

    public OrdersControllerTests()
    {
        // Arrange
        mockOrderService = new Mock<IOrderService>();
        ordersController = new OrdersController(mockOrderService.Object);
    }

    [Fact]
    public void GetAll_Should_Return_OkResult_With_OrderDtos()
    {
        // Arrange
        var expectedDtoOrders = new List<OrderDto>
        {
            new OrderDto { OrderId = 1, OrderedAt = DateTime.Now, NumberOfTickets = 2, TotalPrice = 100 },
            new OrderDto { OrderId = 2, OrderedAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 150 }
        };

        mockOrderService.Setup(s => s.GetAll()).Returns(expectedDtoOrders);

        // Act
        var result = ordersController.GetAll();

        // Assert
        Assert.IsNotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsNotNull(okResult.Value);
        var dtoOrders = Assert.IsAssignableFrom<List<OrderDto>>(okResult.Value);
        Assert.Equal(expectedDtoOrders.Count, dtoOrders.Count);
        Assert.Equal(expectedDtoOrders[0].OrderId, dtoOrders[0].OrderId);
        Assert.Equal(expectedDtoOrders[1].TotalPrice, dtoOrders[1].TotalPrice);
    }

    [Fact]
    public async Task GetById_Should_Return_OkResult_With_OrderDto()
    {
        // Arrange
        int orderId = 1;
        var expectedOrderDto = new OrderDto { OrderId = orderId, OrderedAt = DateTime.Now, NumberOfTickets = 2, TotalPrice = 100 };

        mockOrderService.Setup(s => s.GetById(orderId)).ReturnsAsync(expectedOrderDto);

        // Act
        var result = await ordersController.GetById(orderId);

        // Assert
        Assert.IsNotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsNotNull(okResult.Value);
        var orderDto = Assert.IsAssignableFrom<OrderDto>(okResult.Value);
        Assert.Equal(expectedOrderDto.OrderId, orderDto.OrderId);
        Assert.Equal(expectedOrderDto.TotalPrice, orderDto.TotalPrice);
    }

    [Fact]
    public async Task Delete_Should_Return_OkResult_With_DeletedOrder()
    {
        // Arrange
        int orderId = 1;
        var expectedDeletedOrder = new OrderDto { OrderId = orderId, OrderedAt = DateTime.Now, NumberOfTickets = 2, TotalPrice = 100 };

        mockOrderService.Setup(s => s.GetById(orderId)).ReturnsAsync(expectedDeletedOrder);

        // Act
        var result = await ordersController.Delete(orderId);

        // Assert
        Assert.IsNotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsNotNull(okResult.Value);
        var deletedOrder = Assert.IsAssignableFrom<OrderDto>(okResult.Value);
        Assert.Equal(expectedDeletedOrder.OrderId, deletedOrder.OrderId);
        Assert.Equal(expectedDeletedOrder.TotalPrice, deletedOrder.TotalPrice);

        mockOrderService.Verify(s => s.Delete(orderId), Times.Once);
    }

    [Fact]
    public async Task Patch_Should_Return_OkResult_With_PatchedOrder()
    {
        // Arrange
        var orderPatchDto = new OrderPatchDto { OrderId = 1, NumberOfTickets = 3 };
        var expectedPatchedOrder = new OrderDto { OrderId = orderPatchDto.OrderId, OrderedAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 150 };

        mockOrderService.Setup(s => s.Patch(orderPatchDto)).ReturnsAsync(expectedPatchedOrder);

        // Act
        var result = await ordersController.Patch(orderPatchDto);

        // Assert
        Assert.IsNotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsNotNull(okResult.Value);
        var patchedOrder = Assert.IsAssignableFrom<OrderDto>(okResult.Value);
        Assert.Equal(expectedPatchedOrder.OrderId, patchedOrder.OrderId);
        Assert.Equal(expectedPatchedOrder.NumberOfTickets, patchedOrder.NumberOfTickets);
    }

    [Fact]
    public async Task AddOrder_Should_Return_OkResult_With_OrderId()
    {
        // Arrange
        var orderAddDto = new OrderAddDto { NumberOfTickets = 2 };
        int expectedOrderId = 1;

        mockOrderService.Setup(s => s.AddOrder(orderAddDto)).ReturnsAsync(expectedOrderId);

        // Act
        var result = await ordersController.AddOrder(orderAddDto);

        // Assert
        Assert.IsNotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsNotNull(okResult.Value);
        var orderId = Assert.IsType<int>(okResult.Value);
        Assert.Equal(expectedOrderId, orderId);
    }
}
*/