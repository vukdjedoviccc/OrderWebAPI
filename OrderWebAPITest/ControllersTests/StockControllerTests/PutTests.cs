using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.StockControllerTests;

public class PutTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly StockController _stockController;
    private readonly Mock<IStockService> _stockServiceMock;

    public PutTests()
    {
        _stockServiceMock = new Mock<IStockService>();
        _productServiceMock = new Mock<IProductService>();
        _stockController = new StockController(_stockServiceMock.Object, _productServiceMock.Object);
    }

    [Fact]
    public async Task Put_ValidIdAndValidRequest_UpdatesStockQuantity()
    {
        // Arrange
        var id = 1;
        var stockForUpdate = new CreateStockRequest { ProductId = 1, Quantity = 10 };
        var existingProduct = new Product { Id = 1, Name = "Product 1" };
        var stock = new Stock { Id = 1, ProductId = 1, Quantity = 5 };
        _productServiceMock.Setup(x => x.GetById(stockForUpdate.ProductId)).ReturnsAsync(existingProduct);
        _stockServiceMock.Setup(x => x.GetById(stockForUpdate.ProductId)).ReturnsAsync(stock);
        _stockServiceMock.Setup(x => x.Update(id, stockForUpdate.ProductId, stockForUpdate.Quantity))
            .Returns(Task.CompletedTask);

        // Act
        await _stockController.Put(id, stockForUpdate);

        // Assert
        _stockServiceMock.Verify(x => x.Update(id, stockForUpdate.ProductId, stockForUpdate.Quantity), Times.Once);
        Assert.Equal(stock.ProductId, stockForUpdate.ProductId);
        Assert.Equal(stock.Quantity, stockForUpdate.Quantity);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_WhenIdIsZeroOrNegativeValue_ShouldThrowArgumentException(int id)
    {
        // Arrange
        var request = new CreateStockRequest { ProductId = 1, Quantity = 10 };

        // Act
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Put(id, request));

        // Assert
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _stockServiceMock.Verify(x => x.Update(id, request.ProductId, request.Quantity), Times.Never);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_InvalidProductId_ThrowsArgumentException(int productId)
    {
        // Arrange
        var id = 1;
        var request = new CreateStockRequest { ProductId = productId, Quantity = 10 };
        _productServiceMock.Setup(x => x.GetById(request.ProductId))!.ReturnsAsync((Product?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Put(id, request));
        Assert.Equal("ProductId ne može biti nula ili negativan broj!", ex.Message);
        _stockServiceMock.Verify(x => x.Update(id, request.ProductId, request.Quantity), Times.Never);
    }

    [Fact]
    public async Task Put_WhenProductIsNull_ShouldThrowNullReferenceException()
    {
        // Arrange
        var id = 1;
        var request = new CreateStockRequest { ProductId = 1, Quantity = 10 };
        _productServiceMock.Setup(x => x.GetById(request.ProductId))!.ReturnsAsync((Product?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _stockController.Put(id, request));
        Assert.IsType<NullReferenceException>(ex);
        Assert.Equal($"Proizvod sa Id-jem {request.ProductId} se ne nalazi u bazi!", ex.Message);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_InvalidQuantity_ShouldThrowArgumentException(int quantity)
    {
        // Arrange
        var id = 1;
        var request = new CreateStockRequest { ProductId = 1, Quantity = quantity };
        var product = new Product { Id = 1 };
        _productServiceMock.Setup(x => x.GetById(product.Id)).ReturnsAsync(product);

        // Act & Assert
        _stockServiceMock.Verify(x => x.Update(id, request.ProductId, request.Quantity), Times.Never);
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _stockController.Put(id, request));
        Assert.Contains("Quantity ne može biti nula ili negativan broj!", ex.Message);
    }

    [Fact]
    public async Task Put_ProductNotInStock_ThrowsException()
    {
        // Arrange
        var id = 1;
        var request = new CreateStockRequest { ProductId = 1, Quantity = 10 };
        var product = new Product { Id = 1, Name = "Product" };
        _productServiceMock.Setup(x => x.GetById(request.ProductId)).ReturnsAsync(product);
        _stockServiceMock.Setup(x => x.GetById(request.ProductId))!.ReturnsAsync((Stock?)null);

        // Act & Assert
        _stockServiceMock.Verify(x => x.Update(id, request.ProductId, request.Quantity), Times.Never);
        var ex = await Assert.ThrowsAsync<Exception>(() => _stockController.Put(id, request));
        Assert.Contains($"Proizvod sa id-jem {request.ProductId} se ne nalazi na skladištu!", ex.Message);
    }
}