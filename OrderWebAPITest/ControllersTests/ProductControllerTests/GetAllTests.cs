using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.ProductControllerTests;

public class GetAllTests
{
    private readonly ProductController _productController;
    private readonly Mock<IProductService> _productServiceMock;

    public GetAllTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK()
    {
        // Arrange
        _productServiceMock.Setup(p => p.GetAll())
            .ReturnsAsync(new List<Product>
            {
                new() { Id = 1, Name = "Jakna", Price = 14480, Discount = 10 },
                new() { Id = 2, Name = "Patike", Price = 12200, Discount = 20 },
                new() { Id = 3, Name = "Majica", Price = 3100, Discount = 30 },
                new() { Id = 4, Name = "Dukserica", Price = 5700, Discount = 40 },
                new() { Id = 5, Name = "Farmerke", Price = 4470, Discount = 50 }
            });

        // Act
        var response = await _productController.GetAll();

        // Assert
        var resultValue = response.Value;
        Assert.NotNull(response.Value);
        Assert.IsType<List<Product>>(resultValue);
        var products = (List<Product>?)resultValue;
        Assert.Equal(5, products?.Count);
        Assert.Equal(1, products?.ToArray()[0].Id);
        Assert.Equal("Jakna", products?.ToArray()[0].Name);
        Assert.Equal(14480, products?.ToArray()[0].Price);
        Assert.Equal(10, products?.ToArray()[0].Discount);
        Assert.Equal(2, products?.ToArray()[1].Id);
        Assert.Equal("Patike", products?.ToArray()[1].Name);
        Assert.Equal(12200, products?.ToArray()[1].Price);
        Assert.Equal(20, products?.ToArray()[1].Discount);
        Assert.Equal(3, products?.ToArray()[2].Id);
        Assert.Equal("Majica", products?.ToArray()[2].Name);
        Assert.Equal(3100, products?.ToArray()[2].Price);
        Assert.Equal(30, products?.ToArray()[2].Discount);
        Assert.Equal(4, products?.ToArray()[3].Id);
        Assert.Equal("Dukserica", products?.ToArray()[3].Name);
        Assert.Equal(5700, products?.ToArray()[3].Price);
        Assert.Equal(40, products?.ToArray()[3].Discount);
        Assert.Equal(5, products?.ToArray()[4].Id);
        Assert.Equal("Farmerke", products?.ToArray()[4].Name);
        Assert.Equal(4470, products?.ToArray()[4].Price);
        Assert.Equal(50, products?.ToArray()[4].Discount);
    }

    [Fact]
    public async Task GetAll_EmptyProductList_NullReferenceException()
    {
        // Arrange
        _productServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Product>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _productController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat proizvoda!", ex.Message);
    }
}