using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.OrderControllerTests;

public class GetByIdTests
{
    private readonly OrderController _orderController;
    private readonly Mock<IOrderService> _orderServiceMock;

    public GetByIdTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _orderController = new OrderController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task GetById_OK()
    {
        // Arrange
        var orderId = 1;
        _orderServiceMock.Setup(p => p.GetById(orderId)).ReturnsAsync(new Order.Domain.Model.Order
        {
            Id = orderId,
            Date = DateTime.Today,
            CustomerId = 1,
            TotalAmount = 18730,
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    Id = 1,
                    Amount = 11250,
                    Quantity = 1,
                    ProductId = 1,
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Jakna",
                        Discount = 10,
                        Price = 12500
                    }
                },
                new()
                {
                    Id = 2,
                    Amount = 7480,
                    Quantity = 2,
                    ProductId = 2,
                    Product = new Product
                    {
                        Id = 2,
                        Name = "Dukserica",
                        Discount = 15,
                        Price = 4400
                    }
                }
            }
        });

        // Act
        var response = _orderController.GetById(orderId);

        // Assert
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Once());
        Assert.Equal(orderId, response.Result.Value?.Id);
        Assert.Equal(18730, response.Result.Value?.TotalAmount);
        Assert.Equal(DateTime.Today, response.Result.Value?.Date);
        Assert.Equal(1, response.Result.Value?.CustomerId);
        Assert.Equal(1, response.Result.Value?.OrderItems?[0].Id);
        Assert.Equal(11250, response.Result.Value?.OrderItems?[0].Amount);
        Assert.Equal(1, response.Result.Value?.OrderItems?[0].Quantity);
        Assert.Equal(1, response.Result.Value?.OrderItems?[0].ProductId);
        Assert.Equal(1, response.Result.Value?.OrderItems?[0].Product.Id);
        Assert.Equal("Jakna", response.Result.Value?.OrderItems?[0].Product.Name);
        Assert.Equal(10, response.Result.Value?.OrderItems?[0].Product.Discount);
        Assert.Equal(12500, response.Result.Value?.OrderItems?[0].Product.Price);
        Assert.Equal(2, response.Result.Value?.OrderItems?[1].Id);
        Assert.Equal(7480, response.Result.Value?.OrderItems?[1].Amount);
        Assert.Equal(2, response.Result.Value?.OrderItems?[1].Quantity);
        Assert.Equal(2, response.Result.Value?.OrderItems?[1].ProductId);
        Assert.Equal(2, response.Result.Value?.OrderItems?[1].Product.Id);
        Assert.Equal("Dukserica", response.Result.Value?.OrderItems?[1].Product.Name);
        Assert.Equal(15, response.Result.Value?.OrderItems?[1].Product.Discount);
        Assert.Equal(4400, response.Result.Value?.OrderItems?[1].Product.Price);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_InvalidIdValue_ThrowsArgumentException(int orderId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _orderController.GetById(orderId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _orderServiceMock.Verify(s => s.GetById(orderId), Times.Never());
    }

    [Fact]
    public async Task GetById_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange

        // Act and Assert
        var orderId = 115;
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _orderController.GetById(orderId));
        Assert.Contains($"Objekat sa Id-jem {orderId} se ne nalazi u bazi!", ex.Message);
    }
}