using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.ProductControllerTests;

public class GetByIdTests
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _productServiceMock;

    public GetByIdTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task GetById_OK()
    {
        // Arrange
        var productId = 1;
        _productServiceMock.Setup(p => p.GetById(productId)).ReturnsAsync(new Product
        {
            Id = productId,
            Name = "Rukavice",
            Price = 184,
            Discount = 7
        });

        // Act
        var response = _productController.GetById(productId);

        // Assert
        _productServiceMock.Verify(s => s.GetById(productId), Times.Once());
        Assert.Equal(productId, response.Result.Value?.Id);
        Assert.Equal("Rukavice", response.Result.Value?.Name);
        Assert.Equal(184, response.Result.Value?.Price);
        Assert.Equal(7, response.Result.Value?.Discount);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_InvalidIdValue_ThrowsArgumentException(int productId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _productController.GetById(productId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _productServiceMock.Verify(s => s.GetById(productId), Times.Never());
    }

    [Fact]
    public async Task GetById_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange

        // Act and Assert
        var productId = 115;
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _productController.GetById(productId));
        Assert.Contains($"Objekat sa Id-jem {productId} se ne nalazi u bazi!", ex.Message);
    }
}