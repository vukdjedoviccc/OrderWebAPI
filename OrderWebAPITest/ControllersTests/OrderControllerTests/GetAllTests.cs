using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.OrderControllerTests;

public class GetAllTests
{
    private readonly OrderController _orderController;
    private readonly Mock<IOrderService> _orderServiceMock;

    public GetAllTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _orderController = new OrderController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK()
    {
        // Arrange
        _orderServiceMock.Setup(p => p.GetAll())
            .ReturnsAsync(new List<Order.Domain.Model.Order>
            {
                new(1, 1, DateTime.Today, 2000,
                    new List<OrderItem>(new[] { new OrderItem(1, 10, 2000, 1, new Product(1, "Sveska", 220, 9.09M)) })),
                new(2, 2, DateTime.Today, 4000,
                    new List<OrderItem>(new[] { new OrderItem(2, 10, 4000, 2, new Product(2, "Futrola", 420, 4.76M)) }))
            });

        // Act
        var response = await _orderController.GetAll();

        // Assert
        var resultValue = response.Value;
        Assert.NotNull(response.Value);
        Assert.IsType<List<Order.Domain.Model.Order>>(resultValue);
        var orders = (List<Order.Domain.Model.Order>?)resultValue;
        Assert.Equal(2, orders?.Count);
        Assert.Equal(1, orders?.ToArray()[0].Id);
        Assert.Equal(1, orders?.ToArray()[0].CustomerId);
        Assert.Equal(DateTime.Today, orders?.ToArray()[0].Date);
        Assert.Equal(2000, orders?.ToArray()[0].TotalAmount);
        Assert.Equal(1, orders?.ToArray()[0].OrderItems?[0].Id);
        Assert.Equal(10, orders?.ToArray()[0].OrderItems?[0].Quantity);
        Assert.Equal(2000, orders?.ToArray()[0].OrderItems?[0].Amount);
        Assert.Equal(1, orders?.ToArray()[0].OrderItems?[0].ProductId);
        Assert.Equal(1, orders?.ToArray()[0].OrderItems?[0].Product.Id);
        Assert.Equal("Sveska", orders?.ToArray()[0].OrderItems?[0].Product.Name);
        Assert.Equal(220, orders?.ToArray()[0].OrderItems?[0].Product.Price);
        Assert.Equal(9.09M, orders?.ToArray()[0].OrderItems?[0].Product.Discount);
        Assert.Equal(2, orders?.ToArray()[1].Id);
        Assert.Equal(2, orders?.ToArray()[1].CustomerId);
        Assert.Equal(DateTime.Today, orders?.ToArray()[1].Date);
        Assert.Equal(4000, orders?.ToArray()[1].TotalAmount);
        Assert.Equal(2, orders?.ToArray()[1].OrderItems?[0].Id);
        Assert.Equal(10, orders?.ToArray()[1].OrderItems?[0].Quantity);
        Assert.Equal(4000, orders?.ToArray()[1].OrderItems?[0].Amount);
        Assert.Equal(2, orders?.ToArray()[1].OrderItems?[0].ProductId);
        Assert.Equal(2, orders?.ToArray()[1].OrderItems?[0].Product.Id);
        Assert.Equal("Futrola", orders?.ToArray()[1].OrderItems?[0].Product.Name);
        Assert.Equal(420, orders?.ToArray()[1].OrderItems?[0].Product.Price);
        Assert.Equal(4.76M, orders?.ToArray()[1].OrderItems?[0].Product.Discount);
    }

    [Fact]
    public async Task GetAll_EmptyPersonList_NullReferenceException()
    {
        // Arrange
        _orderServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Order.Domain.Model.Order>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _orderController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat narudžbine!", ex.Message);
    }
}