using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PersonControllerTests;

public class PutTests
{
    private readonly PersonController _personController;
    private readonly Mock<IPersonService> _personServiceMock;

    public PutTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personController = new PersonController(_personServiceMock.Object);
    }

    [Fact]
    public async Task Put_ValidPerson_ShouldUpdatePerson()
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");
        var existingPerson = new Person("Marko", "Marković", "Braće Veličković 134/2, Bačka Palanka",
            "0642355677", "markomarkovic@gmail.com", personId);
        _personServiceMock.Setup(p => p.GetById(personId))
            .ReturnsAsync(existingPerson);

        // Act
        await _personController.Put(personId, personForUpdate);

        // Assert
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Once);
        Assert.Equal(personForUpdate.Adress, existingPerson.Adress);
        Assert.Equal(personForUpdate.FirstName, existingPerson.FirstName);
        Assert.Equal(personForUpdate.Email, existingPerson.Email);
        Assert.Equal(personForUpdate.LastName, existingPerson.LastName);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Put_Invalid_IdValue_ThrowsArgumentException(int personId)
    {
        // Arrange
        var personForUpdate = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_FirstNameValue_ThrowsArgumentException(string firstName)
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest(firstName, "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("FirstName ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_LastNameValue_ThrowsArgumentException(string lastName)
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest("Vuk", lastName, "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("LastName ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_AddressValue_ThrowsArgumentException(string address)
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest("Vuk", "Đedović", address,
            "0655130477", "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("Address ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_PhoneNumberValue_ThrowsArgumentException(string phoneNumber)
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            phoneNumber, "vukdjedovic@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("PhoneNumber ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_EmailValue_ThrowsArgumentException(string email)
    {
        // Arrange
        var personId = 1;
        var personForUpdate = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", email);

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _personController.Put(personId, personForUpdate));
        Assert.Contains("Email ne može biti null ili prazan string!", ex.Message);
        _personServiceMock.Verify(
            p => p.Update(personId, personForUpdate.FirstName, personForUpdate.LastName,
                personForUpdate.Email, personForUpdate.Adress, personForUpdate.PhoneNumber),
            Times.Never);
    }

    [Fact]
    public async Task Put_Invalid_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange
        var personId = 1;
        var productRequest = new CreatePersonRequest("Vuk", "Đedović", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "vukdjedovic@gmail.com");
        _personServiceMock.Setup(p => p.GetById(personId))!
            .ReturnsAsync((Person?)null);
        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(async () =>
            await _personController.Put(personId, productRequest));
        Assert.Contains($"Objekat sa Id-jem {personId} se ne nalazi u bazi!", ex.Message);
    }
}