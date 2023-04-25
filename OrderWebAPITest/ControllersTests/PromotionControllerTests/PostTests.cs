using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PromotionControllerTests;

public class PostTests
{
    private readonly PromotionController _promotionController;
    private readonly Mock<IPromotionService> _promotionServiceMock;

    public PostTests()
    {
        _promotionServiceMock = new Mock<IPromotionService>();
        _promotionController = new PromotionController(_promotionServiceMock.Object);
    }

    [Fact]
    public async Task Post_ValidPromotion_ShouldAddPromotion()
    {
        // Arrange
        var promotionRequest = new CreatePromotionRequest
        {
            Name = "Jakna",
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(30),
            Discount = 7,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        // Act
        await _promotionController.Post(promotionRequest);

        // Assert
        _promotionServiceMock.Verify(
            p => p.Add(promotionRequest.Name, promotionRequest.Discount, promotionRequest.FromDate,
                promotionRequest.ToDate, promotionRequest.ProductIds), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Post_Invalid_NameValue_ThrowsArgumentException(string name)
    {
        // Arrange
        var promotionRequest = new CreatePromotionRequest
        {
            Name = name,
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(30),
            Discount = 7,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _promotionController.Post(promotionRequest));
        Assert.Contains("Name ne može biti null ili prazan string!", ex.Message);
        _promotionServiceMock.Verify(
            p => p.Add(promotionRequest.Name, promotionRequest.Discount, promotionRequest.FromDate,
                promotionRequest.ToDate, promotionRequest.ProductIds),
            Times.Never);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Post_Invalid_DiscountValue_ThrowsArgumentException(decimal discount)
    {
        // Arrange
        var promotionRequest = new CreatePromotionRequest
        {
            Name = "Letnja",
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(30),
            Discount = discount,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _promotionController.Post(promotionRequest));
        Assert.Contains("Discount ne može biti negativan broj ili jednak nuli!", ex.Message);
        _promotionServiceMock.Verify(
            p => p.Add(promotionRequest.Name, promotionRequest.Discount, promotionRequest.FromDate,
                promotionRequest.ToDate, promotionRequest.ProductIds),
            Times.Never);
    }
}