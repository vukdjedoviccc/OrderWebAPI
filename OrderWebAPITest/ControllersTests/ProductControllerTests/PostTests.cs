using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.ProductControllerTests;

public class PostTests
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _productServiceMock;

    public PostTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task Post_ValidProduct_ShouldAddProduct()
    {
        // Arrange
        var productRequest = new CreateProductRequest
        {
            Name = "Product 1",
            Price = 9.99m
        };

        // Act
        await _productController.Post(productRequest);

        // Assert
        _productServiceMock.Verify(p => p.AddProduct(productRequest.Name, productRequest.Price), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Post_Invalid_NameValue_ShouldThrowsArgumentException(string name)
    {
        // Arrange
        var productRequest = new CreateProductRequest();
        productRequest.Name = name;
        productRequest.Price = 2780.99M;

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _productController.Post(productRequest));
        Assert.Contains("Name ne može biti null ili prazan string!", ex.Message);
        _productServiceMock.Verify(p => p.AddProduct(productRequest.Name, productRequest.Price), Times.Never);
    }

    [Theory]
    [InlineData(-1200.34)]
    [InlineData(0)]
    public async Task Post_Invalid_PriceValue_ShouldThrowsArgumentException(decimal price)
    {
        // Arrange
        var productRequest = new CreateProductRequest();
        productRequest.Name = "Ranac";
        productRequest.Price = price;

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _productController.Post(productRequest));
        Assert.Contains("Price ne može biti nula ili negativan broj!", ex.Message);
        _productServiceMock.Verify(
            p => p.AddProduct(productRequest.Name, productRequest.Price), Times.Never);
    }
}