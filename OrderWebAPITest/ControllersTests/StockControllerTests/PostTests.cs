using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.StockControllerTests;

public class PostTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly StockController _stockController;
    private readonly Mock<IStockService> _stockServiceMock;

    public PostTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _stockServiceMock = new Mock<IStockService>();
        _stockController = new StockController(_stockServiceMock.Object, _productServiceMock.Object);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Post_ThrowsArgumentException_WhenProductIdIsInvalid(int productId)
    {
        // Arrange
        var request = new CreateStockRequest
        {
            ProductId = productId,
            Quantity = 10
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Post(request));
        Assert.Contains("ProductId ne može biti nula ili negativan broj!", ex.Message);
        _productServiceMock.Verify(p => p.GetById(productId), Times.Never);
        _stockServiceMock.Verify(p => p.GetById(productId), Times.Never);
        _stockServiceMock.Verify(p => p.Add(productId, It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public async Task Add_NonExistingProductToStock_ShouldThrowArgumentException()
    {
        // Arrange
        var productId = 1;
        var quantity = 10;
        var request = new CreateStockRequest { ProductId = productId, Quantity = quantity };
        var product = (Product?)null;

        _productServiceMock.Setup(p => p.GetById(productId))!.ReturnsAsync(product);

        // Act && Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Post(request));
        Assert.Contains($"Proizvod sa Id-jem {productId} se ne nalazi u bazi!", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Post_ThrowsArgumentException_WhenQuantityIsInvalid(int quantity)
    {
        // Arrange
        var productId = 1;
        var request = new CreateStockRequest
        {
            ProductId = productId,
            Quantity = quantity
        };
        _productServiceMock.Setup(p => p.GetById(productId)).ReturnsAsync(new Product(5, "Jakna", 7500, 12));

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Post(request));
        Assert.Contains("Quantity ne može biti nula ili negativan broj!", ex.Message);
        _productServiceMock.Verify(p => p.GetById(productId), Times.Once);
        _stockServiceMock.Verify(p => p.GetById(productId), Times.Never);
        _stockServiceMock.Verify(p => p.Add(productId, quantity), Times.Never);
    }

    [Fact]
    public async Task Post_AddsNewProductToStock()
    {
        // Arrange
        var productId = 1;
        var quantity = 10;
        var request = new CreateStockRequest
        {
            ProductId = productId,
            Quantity = quantity
        };
        _productServiceMock.Setup(p => p.GetById(productId)).ReturnsAsync(new Product(5, "Jakna", 7500, 12));
        _stockServiceMock.Setup(p => p.GetById(productId))!.ReturnsAsync((Stock?)null);
        _stockServiceMock.Setup(p => p.Add(productId, quantity)).Returns(Task.CompletedTask);

        // Act
        await _stockController.Post(request);

        // Assert
        _productServiceMock.Verify(p => p.GetById(productId), Times.Once);
        _stockServiceMock.Verify(p => p.GetById(productId), Times.Once);
        _stockServiceMock.Verify(p => p.Add(productId, quantity), Times.Once);
    }

    [Fact]
    public async Task Post_ThrowsException_WhenProductAlreadyExistsOnStock()
    {
        // Arrange
        var productId = 1;
        var quantity = 10;
        var request = new CreateStockRequest
        {
            ProductId = productId,
            Quantity = quantity
        };
        _productServiceMock.Setup(p => p.GetById(productId)).ReturnsAsync(new Product(5, "Jakna", 7500, 12));
        _stockServiceMock.Setup(p => p.GetById(productId)).ReturnsAsync(new Stock(1, productId, quantity));

        // Act and Assert
        var ex = await Assert.ThrowsAsync<Exception>(() => _stockController.Post(request));
        _productServiceMock.Verify(p => p.GetById(productId), Times.Once);
        _stockServiceMock.Verify(p => p.GetById(productId), Times.Once);
        _stockServiceMock.Verify(p => p.Add(productId, quantity), Times.Never);
        Assert.Contains($"Proizvod sa id-jem {productId} se već nalazi na skladištu!", ex.Message);
    }
}