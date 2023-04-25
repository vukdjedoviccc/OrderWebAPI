using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.ProductControllerTests;

public class DeleteTests
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _productServiceMock;

    public DeleteTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task Delete_OK()
    {
        // Arrange
        var productId = 1;
        _productServiceMock.Setup(p => p.Delete(productId)).Returns(Task.CompletedTask);

        // Act
        var response = _productController.Delete(productId);

        // Assert
        _productServiceMock.Verify(s => s.Delete(productId), Times.Once());
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Delete_InvalidProductIdValue_ThrowsArgumentException(int productId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _productController.Delete(productId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _productServiceMock.Verify(s => s.Delete(productId), Times.Never());
    }
}