using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PersonControllerTests;

public class PostTests
{
    private readonly PersonController _personController;
    private readonly Mock<IPersonService> _personServiceMock;

    public PostTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personController = new PersonController(_personServiceMock.Object);
    }

    [Fact]
    public async Task Post_ValidPerson_ShouldAddPerson()
    {
        // Arrange
        var personRequest = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act
        await _personController.Post(personRequest);

        // Assert
        _personServiceMock.Verify(p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
            personRequest.Address,
            personRequest.PhoneNumber), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_FirstNameValue_ShouldThrowsArgumentException(string firstName)
    {
        // Arrange
        var personRequest = new CreatePersonRequest(firstName, "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Post(personRequest));
        Assert.Contains("FirstName ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
                personRequest.Address, personRequest.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_LastNameValue_ShouldThrowsArgumentException(string lastName)
    {
        // Arrange
        var personRequest = new CreatePersonRequest("Vuk", lastName, "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Post(personRequest));
        Assert.Contains("LastName ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
                personRequest.Address, personRequest.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_PhoneNumberValue_ShouldThrowsArgumentException(string phoneNumber)
    {
        // Arrange
        var personRequest = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            phoneNumber, "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Post(personRequest));
        Assert.Contains("PhoneNumber ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
                personRequest.Address, personRequest.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_AddressValue_ShouldThrowsArgumentException(string address)
    {
        // Arrange
        var personRequest = new CreatePersonRequest("Vuk", "Đedović", address,
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Post(personRequest));
        Assert.Contains("Address ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
                personRequest.Address, personRequest.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_EmailValue_ShouldThrowsArgumentException(string email)
    {
        // Arrange
        var personRequest = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", email);

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Post(personRequest));
        Assert.Contains("Email ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Add(personRequest.FirstName, personRequest.LastName, personRequest.Email,
                personRequest.Address, personRequest.PhoneNumber),
            Times.Never);
    }
}