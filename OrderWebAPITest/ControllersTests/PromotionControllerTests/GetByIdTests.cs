using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PromotionControllerTests;

public class GetByIdTests
{
    private readonly PromotionController _promotionController;
    private readonly Mock<IPromotionService> _promotionServiceMock;

    public GetByIdTests()
    {
        _promotionServiceMock = new Mock<IPromotionService>();
        _promotionController = new PromotionController(_promotionServiceMock.Object);
    }

    [Fact]
    public async Task GetById_OK()
    {
        // Arrange
        var promotionId = 1;
        _promotionServiceMock.Setup(p => p.GetById(promotionId)).ReturnsAsync(new Promotion
        {
            Id = promotionId,
            Name = "Rukavice",
            Discount = 7,
            FromDate = DateTime.Today,
            ToDate = DateTime.Today.AddDays(30),
            Products = new List<Product>(new[] { new Product(1, "Jakna", 12899.99M, 7) })
        });

        // Act
        var response = _promotionController.GetById(promotionId);

        // Assert
        _promotionServiceMock.Verify(s => s.GetById(promotionId), Times.Once());
        Assert.Equal(promotionId, response?.Result?.Value?.Id);
        Assert.Equal("Rukavice", response?.Result?.Value?.Name);
        Assert.Equal(7, response?.Result?.Value?.Discount);
        Assert.Equal(DateTime.Today, response?.Result?.Value?.FromDate);
        Assert.Equal(DateTime.Today.AddDays(30), response?.Result?.Value?.ToDate);
        Assert.NotNull(response?.Result?.Value?.Products);
        Assert.Equal(1, response?.Result?.Value?.Products[0].Id);
        Assert.Equal("Jakna", response?.Result?.Value?.Products[0].Name);
        Assert.Equal(12899.99M, response?.Result?.Value?.Products[0].Price);
        Assert.Equal(7, response?.Result?.Value?.Products[0].Discount);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_InvalidIdValue_ThrowsArgumentException(int promotionId)
    {
        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _promotionController.GetById(promotionId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _promotionServiceMock.Verify(s => s.GetById(promotionId), Times.Never());
    }

    [Fact]
    public async Task GetById_CompanyIdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange

        // Act and Assert
        var companyId = 115;
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _promotionController.GetById(companyId));
        Assert.Contains($"Objekat sa Id-jem {companyId} se ne nalazi u bazi!", ex.Message);
    }
}