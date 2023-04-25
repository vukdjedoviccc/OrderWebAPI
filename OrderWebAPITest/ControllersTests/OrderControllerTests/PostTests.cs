using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.OrderControllerTests;

public class PostTests
{
    private readonly OrderController _orderController;
    private readonly Mock<IOrderService> _orderServiceMock;

    public PostTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _orderController = new OrderController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Post_ValidOrder_ShouldAddsOrder()
    {
        // Arrange
        var orderRequest = new CreateOrderRequest
        {
            CustomerId = 1,
            Date = new DateTime(2023, 4, 18),
            Items = new List<OrderItem>
            {
                new() { ProductId = 1, Quantity = 1 },
                new() { ProductId = 2, Quantity = 1 }
            }
        };

        // Act
        await _orderController.Post(orderRequest);

        // Assert
        _orderServiceMock.Verify(p => p.Add(orderRequest.CustomerId, orderRequest.Date, It.IsAny<List<OrderItem>>()),
            Times.Once);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Post_Invalid_CustomerIdZeroValue_ThrowsArgumentException(int customerId)
    {
        // Arrange
        var orderRequest = new CreateOrderRequest
        {
            CustomerId = customerId,
            Date = DateTime.Now,
            Items = new List<OrderItem>
            {
                new() { ProductId = 1, Quantity = 1 },
                new() { ProductId = 2, Quantity = 2 }
            }
        };

        // Act and Assert
        _orderServiceMock.Verify(s => s.Add(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
        var ex = await Assert.ThrowsAsync<ArgumentException>(async () => await _orderController.Post(orderRequest));
        Assert.Equal("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
    }

    [Fact]
    public async Task Post_Invalid_ItemsNullValue_ThrowsArgumentException()
    {
        // Arrange
        var orderRequest = new CreateOrderRequest
        {
            CustomerId = 1,
            Date = DateTime.Now,
            Items = null
        };

        // Act and Assert
        _orderServiceMock.Verify(s => s.Add(orderRequest.CustomerId, orderRequest.Date, orderRequest.Items),
            Times.Never);
        var ex = await Assert.ThrowsAsync<ArgumentException>(async () => await _orderController.Post(orderRequest));
        Assert.Equal("Items ne može biti null!", ex.Message);
    }
}