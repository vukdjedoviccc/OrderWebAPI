using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.OrderControllerTests;

public class PutTests
{
    private readonly OrderController _orderController;
    private readonly Mock<IOrderService> _orderServiceMock;

    public PutTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _orderController = new OrderController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Put_UpdatesOrder()
    {
        // Arrange
        var orderId = 1;
        var orderRequest = new CreateOrderRequest
        {
            Date = DateTime.Now,
            CustomerId = 2,
            Items = new List<OrderItem>
            {
                new() { ProductId = 1, Quantity = 2 },
                new() { ProductId = 3, Quantity = 1 }
            }
        };
        var expectedOrder = new Order.Domain.Model.Order
        {
            Id = orderId,
            Date = orderRequest.Date,
            CustomerId = orderRequest.CustomerId,
            OrderItems = orderRequest.Items.Select(or => new OrderItem
            {
                ProductId = or.ProductId,
                Quantity = or.Quantity
            }).ToList()
        };
        _orderServiceMock.Setup(x => x.GetById(orderId)).ReturnsAsync(expectedOrder);

        // Act
        await _orderController.Put(orderId, orderRequest);

        // Assert
        _orderServiceMock.Verify(x => x.Update(expectedOrder.CustomerId, expectedOrder.Date, expectedOrder.OrderItems),
            Times.Once);
        Assert.Equal(orderRequest.Date, expectedOrder.Date);
        Assert.Equal(orderRequest.CustomerId, expectedOrder.CustomerId);
        Assert.Equal(orderRequest.Items[0].Quantity, expectedOrder.OrderItems[0].Quantity);
        Assert.Equal(orderRequest.Items[0].ProductId, expectedOrder.OrderItems[0].ProductId);
        Assert.Equal(orderRequest.Items[1].Quantity, expectedOrder.OrderItems[1].Quantity);
        Assert.Equal(orderRequest.Items[1].ProductId, expectedOrder.OrderItems[1].ProductId);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_OrderIdValue_ThrowsArgumentException(int orderId)
    {
        var orderRequest = new CreateOrderRequest
        {
            Date = new DateTime(2023, 4, 18),
            CustomerId = 2,
            Items = new List<OrderItem>
            {
                new() { ProductId = 3, Quantity = 2 },
                new() { ProductId = 4, Quantity = 1 }
            }
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _orderController.Put(orderId, orderRequest));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Never);
        _orderServiceMock.Verify(s => s.Update(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_CustomerIdValue_ThrowsArgumentException(int customerId)
    {
        // Arrange
        var orderId = 1;
        var orderRequest = new CreateOrderRequest
        {
            Date = new DateTime(2023, 4, 18),
            CustomerId = customerId,
            Items = new List<OrderItem>
            {
                new() { ProductId = 3, Quantity = 2 },
                new() { ProductId = 4, Quantity = 1 }
            }
        };

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _orderController.Put(orderId, orderRequest));
        Assert.Contains("CustomerId ne može biti negativan broj ili jednak nuli!", ex.Message);
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Never);
        _orderServiceMock.Verify(s => s.Update(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
    }


    [Fact]
    public async Task Put_Invalid_ItemsNullValue_ThrowsArgumentException()
    {
        // Arrange
        var orderId = 1;
        var orderRequest = new CreateOrderRequest
        {
            Date = new DateTime(2023, 4, 18),
            CustomerId = 2,
            Items = null
        };

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _orderController.Put(orderId, orderRequest));
        Assert.Contains("Items ne može biti null!", ex.Message);
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Never);
        _orderServiceMock.Verify(s => s.Update(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
    }

    [Fact]
    public async Task Put_Invalid_OrderIdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange
        var orderId = 1;
        var orderRequest = new CreateOrderRequest
        {
            Date = new DateTime(2023, 4, 18),
            CustomerId = 2,
            Items = new List<OrderItem>
            {
                new() { ProductId = 3, Quantity = 2 },
                new() { ProductId = 4, Quantity = 1 }
            }
        };
        _orderServiceMock.Setup(s => s.GetById(orderId))!.ReturnsAsync((Order.Domain.Model.Order?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _orderController.Put(orderId, orderRequest));
        Assert.Contains($"Objekat sa Id-jem {orderId} se ne nalazi u bazi!", ex.Message);
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Once);
        _orderServiceMock.Verify(s => s.Update(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
    }
}