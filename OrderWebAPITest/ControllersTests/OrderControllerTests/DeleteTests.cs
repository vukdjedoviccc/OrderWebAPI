using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.OrderControllerTests;

public class DeleteTests
{
    private readonly OrderController _orderController;
    private readonly Mock<IOrderService> _orderServiceMock;

    public DeleteTests()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _orderController = new OrderController(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Delete_OK()
    {
        // Arrange
        var orderId = 1;
        _orderServiceMock.Setup(p => p.Delete(orderId)).Returns(Task.CompletedTask);

        // Act
        await _orderController.Delete(orderId);

        // Assert
        _orderServiceMock.Verify(s => s.Delete(orderId), Times.Once());
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Delete_InvalidIdValue_ThrowsArgumentException(int orderId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _orderController.Delete(orderId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _orderServiceMock.Verify(s => s.Delete(orderId), Times.Never());
    }
}