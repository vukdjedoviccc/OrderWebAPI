using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.ProductControllerTests;

public class PutTests
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _productServiceMock;

    public PutTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task Put_ValidPerson_ShouldUpdatePerson()
    {
        // Arrange
        var productId = 1;
        var productForUpdate = new CreateProductRequest
        {
            Name = "Updated Product",
            Price = 19.99m
        };
        var existingProduct = new Product
        {
            Id = productId,
            Name = "Product",
            Price = 9.99m
        };
        _productServiceMock.Setup(p => p.GetById(productId))
            .ReturnsAsync(existingProduct);

        // Act
        await _productController.Put(productId, productForUpdate);

        // Assert
        _productServiceMock.Verify(
            p => p.Update(productId, productForUpdate.Name, productForUpdate.Price), Times.Once);
        Assert.Equal(productForUpdate.Name, existingProduct.Name);
        Assert.Equal(productForUpdate.Price, existingProduct.Price);
        ;
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_ProductIdValue_ThrowsArgumentException(int productId)
    {
        // Arrange
        var productForUpdate = new CreateProductRequest
        {
            Name = "Updated Product",
            Price = 19.99m
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _productController.Put(productId, productForUpdate));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _productServiceMock.Verify(
            p => p.Update(productId, productForUpdate.Name, productForUpdate.Price),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_NameValue_ThrowsArgumentException(string name)
    {
        // Arrange
        var productId = 1;
        var productForUpdate = new CreateProductRequest
        {
            Name = name,
            Price = 19.99m
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _productController.Put(productId, productForUpdate));
        Assert.Contains("Name ne može biti null ili prazan string!", ex.Message);
        _productServiceMock.Verify(
            p => p.Update(productId, productForUpdate.Name, productForUpdate.Price),
            Times.Never);
    }

    [Theory]
    [InlineData(-11100)]
    [InlineData(0)]
    public async Task Put_Invalid_PriceValue_ThrowsArgumentException(decimal price)
    {
        // Arrange
        var productId = 1;
        var productForUpdate = new CreateProductRequest
        {
            Name = "Product",
            Price = price
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _productController.Put(productId, productForUpdate));
        Assert.Contains("Price ne može biti nula ili negativan broj!", ex.Message);
        _productServiceMock.Verify(
            p => p.Update(productId, productForUpdate.Name, productForUpdate.Price),
            Times.Never);
    }

    [Fact]
    public async Task Put_Invalid_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange
        var productId = 1;
        var productForUpdate = new CreateProductRequest
        {
            Name = "Product",
            Price = 1200.12M
        };
        _productServiceMock.Setup(p => p.GetById(productId))!
            .ReturnsAsync((Product?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(async () =>
            await _productController.Put(productId, productForUpdate));
        Assert.Contains($"Objekat sa Id-jem {productId} se ne nalazi u bazi!", ex.Message);
    }
}