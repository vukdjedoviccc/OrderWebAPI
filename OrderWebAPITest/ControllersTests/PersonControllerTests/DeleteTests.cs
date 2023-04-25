using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PersonControllerTests;

public class DeleteTests
{
    private readonly PersonController _personController;
    private readonly Mock<IPersonService> _personServiceMock;

    public DeleteTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personController = new PersonController(_personServiceMock.Object);
    }

    [Fact]
    public async Task Delete_OK()
    {
        // Arrange
        var personId = 1;
        _personServiceMock.Setup(p => p.Delete(personId)).Returns(Task.CompletedTask);

        // Act
        var response = _personController.Delete(personId);

        // Assert
        _personServiceMock.Verify(s => s.Delete(personId), Times.Once());
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Delete_InvalidIdValue_ThrowsArgumentException(int personId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _personController.Delete(personId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _personServiceMock.Verify(s => s.Delete(personId), Times.Never());
    }
}