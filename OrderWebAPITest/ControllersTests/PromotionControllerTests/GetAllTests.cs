using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PromotionControllerTests;

public class GetAllTests
{
    private readonly PromotionController _promotionController;
    private readonly Mock<IPromotionService> _promotionServiceMock;

    public GetAllTests()
    {
        _promotionServiceMock = new Mock<IPromotionService>();
        _promotionController = new PromotionController(_promotionServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK_ReturnsListOfPromotions()
    {
        // Arrange
        var expectedPromotions = new List<Promotion>
        {
            new()
            {
                Id = 1,
                Name = "Prolećna",
                Discount = 10,
                FromDate = DateTime.Now.AddDays(5),
                ToDate = DateTime.Now.AddDays(10),
                Products = new List<Product>()
            },
            new()
            {
                Id = 2,
                Name = "Letnja",
                Discount = 20,
                FromDate = DateTime.Now.AddDays(15),
                ToDate = DateTime.Today.AddDays(20),
                Products = new List<Product>()
            },
            new()
            {
                Id = 3,
                Name = "Zimska",
                Discount = 30,
                FromDate = DateTime.Now.AddDays(25),
                ToDate = DateTime.Today.AddDays(30),
                Products = new List<Product>()
            }
        };
        _promotionServiceMock.Setup(x => x.GetAll()).ReturnsAsync(expectedPromotions);

        // Act
        var response = await _promotionController.GetAll();
        var resultValue = response.Value;
        var actualPromotions = resultValue;

        // Assert
        Assert.NotNull(actualPromotions);
        Assert.IsType<List<Promotion>>(actualPromotions);
        Assert.Equal(expectedPromotions.Count, actualPromotions?.Count);
        for (var i = 0; i < expectedPromotions.Count; i++)
        {
            Assert.Equal(expectedPromotions[i].Id, actualPromotions?[i].Id);
            Assert.Equal(expectedPromotions[i].Name, actualPromotions?[i].Name);
            Assert.Equal(expectedPromotions[i].Discount, actualPromotions?[i].Discount);
            Assert.Equal(expectedPromotions[i].FromDate, actualPromotions?[i].FromDate);
            Assert.Equal(expectedPromotions[i].ToDate, actualPromotions?[i].ToDate);
            Assert.NotNull(actualPromotions?[i].Products);
        }
    }


    [Fact]
    public async Task GetAll_EmptyProductList_NullReferenceException()
    {
        // Arrange
        _promotionServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Promotion>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _promotionController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat promocije!", ex.Message);
    }
}