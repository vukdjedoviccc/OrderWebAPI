using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PersonControllerTests;

public class GetByIdTests
{
    private readonly PersonController _personController;
    private readonly Mock<IPersonService> _personServiceMock;

    public GetByIdTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personController = new PersonController(_personServiceMock.Object);
    }

    [Fact]
    public async Task GetById_OK()
    {
        // Arrange
        var personId = 1;
        _personServiceMock.Setup(p => p.GetById(personId)).ReturnsAsync(new Person
        {
            Id = 1, FirstName = "Vuk", LastName = "Đedović", Address = "Dragojla Lazića 18/1, Valjevo",
            Email = "vukdjedovic@gmail.com", PhoneNumber = "0655130477"
        });

        // Act
        var response = _personController.GetById(personId);

        // Assert
        _personServiceMock.Verify(s => s.GetById(personId), Times.Once());
        Assert.Equal(personId, response.Result.Value?.Id);
        Assert.Equal("Vuk", response.Result.Value?.FirstName);
        Assert.Equal("Đedović", response.Result.Value?.LastName);
        Assert.Equal("Dragojla Lazića 18/1, Valjevo", response.Result.Value?.Address);
        Assert.Equal("vukdjedovic@gmail.com", response.Result.Value?.Email);
        Assert.Equal("0655130477", response.Result.Value?.PhoneNumber);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_InvalidIdZeroValue_ThrowsArgumentException(int personId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _personController.GetById(personId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _personServiceMock.Verify(s => s.GetById(personId), Times.Never());
    }

    [Fact]
    public async Task GetById_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange

        // Act and Assert
        var personId = 115;
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _personController.GetById(personId));
        Assert.Contains($"Objekat sa Id-jem {personId} se ne nalazi u bazi!", ex.Message);
    }
}