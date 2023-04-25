using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PromotionControllerTests;

public class PutTests
{
    private readonly PromotionController _promotionController;
    private readonly Mock<IPromotionService> _promotionServiceMock;

    public PutTests()
    {
        _promotionServiceMock = new Mock<IPromotionService>();
        _promotionController = new PromotionController(_promotionServiceMock.Object);
    }

    [Fact]
    public async Task Put_ValidPromotion_ShouldUpdatePromotion()
    {
        // Arrange
        var id = 1;
        var promotionForUpdate = new CreatePromotionRequest
        {
            Name = "New Promotion",
            Discount = 10,
            FromDate = DateTime.UtcNow,
            ToDate = DateTime.UtcNow.AddDays(7),
            ProductIds = new List<int> { 1, 2, 3 }
        };

        var existingPromotion = new Promotion
        {
            Id = id,
            Name = "Existing Promotion",
            Discount = 20,
            FromDate = DateTime.UtcNow.AddDays(-7),
            ToDate = DateTime.UtcNow.AddDays(7),
            Products = new List<Product> { new() { Id = 7 }, new() { Id = 17 }, new() { Id = 19 } }
        };

        _promotionServiceMock
            .Setup(x => x.GetById(id))
            .ReturnsAsync(existingPromotion);

        // Act
        await _promotionController.Put(id, promotionForUpdate);

        // Assert
        _promotionServiceMock.Verify(
            x => x.Update(promotionForUpdate.Name, promotionForUpdate.Discount, promotionForUpdate.ToDate,
                promotionForUpdate.FromDate, promotionForUpdate.ProductIds), Times.Once);
        Assert.Equal(promotionForUpdate.Name, existingPromotion.Name);
        Assert.Equal(promotionForUpdate.Discount, existingPromotion.Discount);
        Assert.Equal(promotionForUpdate.FromDate, existingPromotion.FromDate);
        Assert.Equal(promotionForUpdate.ToDate, existingPromotion.ToDate);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_PromotionIdValue_ThrowsArgumentException(int promotionId)
    {
        // Arrange
        var promotionForUpdate = new CreatePromotionRequest
        {
            Name = "Jakna",
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(30),
            Discount = 7,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _promotionController.Put(promotionId, promotionForUpdate));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _promotionServiceMock.Verify(
            p => p.Update(promotionForUpdate.Name, promotionForUpdate.Discount, promotionForUpdate.FromDate,
                promotionForUpdate.ToDate, promotionForUpdate.ProductIds), Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Put_Invalid_NameValue_ThrowsArgumentException(string name)
    {
        // Arrange
        var promotionId = 1;
        var promotionForUpdate = new CreatePromotionRequest
        {
            Name = name,
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(10),
            Discount = 7,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _promotionController.Put(promotionId, promotionForUpdate));
        Assert.Contains("Name ne može biti null ili prazan string!", ex.Message);
        _promotionServiceMock.Verify(
            p => p.Update(promotionForUpdate.Name, promotionForUpdate.Discount, promotionForUpdate.FromDate,
                promotionForUpdate.ToDate, promotionForUpdate.ProductIds), Times.Never);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_DiscountValue_ThrowsArgumentException(decimal discount)
    {
        // Arrange
        var promotionId = 1;
        var promotionForUpdate = new CreatePromotionRequest
        {
            Name = "Letnja",
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(10),
            Discount = discount,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _promotionController.Put(promotionId, promotionForUpdate));
        Assert.Contains("Discount ne može biti negativan broj ili jednak nuli!", ex.Message);
        _promotionServiceMock.Verify(
            p => p.Update(promotionForUpdate.Name, promotionForUpdate.Discount, promotionForUpdate.FromDate,
                promotionForUpdate.ToDate, promotionForUpdate.ProductIds), Times.Never);
    }

    [Fact]
    public async Task Put_Invalid_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange
        var promotionId = 1;
        var companyRequest = new CreatePromotionRequest
        {
            Name = "Letnja",
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(10),
            Discount = 10,
            ProductIds = new List<int>(new[] { 1, 2, 3 })
        };
        _promotionServiceMock.Setup(p => p.GetById(promotionId))!
            .ReturnsAsync((Promotion?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(async () =>
            await _promotionController.Put(promotionId, companyRequest));
        Assert.Contains($"Objekat sa Id-jem {promotionId} se ne nalazi u bazi!", ex.Message);
    }
}