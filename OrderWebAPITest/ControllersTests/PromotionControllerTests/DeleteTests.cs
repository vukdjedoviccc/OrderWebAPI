using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PromotionControllerTests;

public class DeleteTests
{
    private readonly PromotionController _promotionController;
    private readonly Mock<IPromotionService> _promotionServiceMock;

    public DeleteTests()
    {
        _promotionServiceMock = new Mock<IPromotionService>();
        _promotionController = new PromotionController(_promotionServiceMock.Object);
    }

    [Fact]
    public async Task Delete_OK()
    {
        // Arrange
        var promotionId = 1;
        _promotionServiceMock.Setup(p => p.DeleteById(promotionId)).Returns(Task.CompletedTask);

        // Act
        await _promotionController.DeleteById(promotionId);

        // Assert
        _promotionServiceMock.Verify(s => s.DeleteById(promotionId), Times.Once());
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Delete_InvalidPromotionIdValue_ThrowsArgumentException(int promotionId)
    {
        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _promotionController.DeleteById(promotionId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _promotionServiceMock.Verify(s => s.DeleteById(promotionId), Times.Never());
    }
}