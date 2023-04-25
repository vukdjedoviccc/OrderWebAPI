using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.StockControllerTests;

public class GetAllTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly StockController _stockController;
    private readonly Mock<IStockService> _stockServiceMock;

    public GetAllTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _stockServiceMock = new Mock<IStockService>();
        _stockController = new StockController(_stockServiceMock.Object, _productServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK()
    {
        // Arrange
        _stockServiceMock.Setup(p => p.GetAll())
            .ReturnsAsync(new List<Stock>
            {
                new()
                {
                    Id = 1,
                    Quantity = 10,
                    ProductId = 1
                },
                new()
                {
                    Id = 2,
                    Quantity = 20,
                    ProductId = 2
                },
                new()
                {
                    Id = 3,
                    Quantity = 30,
                    ProductId = 3
                }
            });

        // Act
        var response = await _stockController.GetAll();

        // Assert
        var resultValue = response.Value;
        Assert.NotNull(response.Value);
        Assert.IsType<List<Stock>>(resultValue);
        var stocks = (List<Stock>?)resultValue;
        Assert.Equal(3, stocks?.Count);
        Assert.Equal(1, stocks?.ToArray()[0].Id);
        Assert.Equal(10, stocks?.ToArray()[0].Quantity);
        Assert.Equal(1, stocks?.ToArray()[0].ProductId);
        Assert.Equal(2, stocks?.ToArray()[1].Id);
        Assert.Equal(20, stocks?.ToArray()[1].Quantity);
        Assert.Equal(2, stocks?.ToArray()[1].ProductId);
        Assert.Equal(3, stocks?.ToArray()[2].Id);
        Assert.Equal(30, stocks?.ToArray()[2].Quantity);
        Assert.Equal(3, stocks?.ToArray()[2].ProductId);
    }

    [Fact]
    public async Task GetAll_EmptyStockList_NullReferenceException()
    {
        // Arrange
        _stockServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Stock>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _stockController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat skladišta!", ex.Message);
    }
}