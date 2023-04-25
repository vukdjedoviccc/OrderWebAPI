using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.CompanyControllerTests;

public class PutTests
{
    private readonly CompanyController _companyController;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public PutTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task Put_ValidCompany_ShouldUpdateCompany()
    {
        // Arrange
        var companyId = 1;
        var companyForUpdate = new CreateCompanyRequest("Intelisale", "01234567", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "intelisale@gmail.com");
        var existingCompany = new Company("Silaris Solutions", "12345678", "Braće Veličković 134/2, Bačka Palanka",
            "0642355677", "silaris@gmail.com", companyId);
        _companyServiceMock.Setup(p => p.GetById(companyId))
            .ReturnsAsync(existingCompany);

        // Act
        await _companyController.Put(companyId, companyForUpdate);

        // Assert
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Once);
        Assert.Equal(companyForUpdate.Adress, existingCompany.Adress);
        Assert.Equal(companyForUpdate.FullName, existingCompany.FullName);
        Assert.Equal(companyForUpdate.Email, existingCompany.Email);
        Assert.Equal(companyForUpdate.PhoneNumber, existingCompany.PhoneNumber);
        Assert.Equal(companyForUpdate.RegistrationNumber, existingCompany.RegistrationNumber);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Put_Invalid_IdValue_ThrowsArgumentException(int companyId)
    {
        // Arrange
        var companyForUpdate = new CreateCompanyRequest("Intelisale", "01234567", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "intelisale@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_AddressValue_ThrowsArgumentException(string address)
    {
        // Arrange
        var companyId = 11;
        var companyForUpdate = new CreateCompanyRequest("Intelisale", "01234567", address,
            "0655130477", "intelisale@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("Address ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_FullNameValue_ThrowsArgumentException(string fullName)
    {
        // Arrange
        var companyId = 11;
        var companyForUpdate = new CreateCompanyRequest(fullName, "01234567", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "intelisale@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("FullName ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_PhoneNumberValue_ThrowsArgumentException(string phoneNumber)
    {
        // Arrange
        var companyId = 11;
        var companyForUpdate = new CreateCompanyRequest("Intelisale", "12345678", "Dragojla Lazića 18/1, Valjevo",
            phoneNumber, "intelisale@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("PhoneNumber ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_EmailValue_ThrowsArgumentException(string email)
    {
        // Arrange
        var companyId = 11;
        var companyForUpdate = new CreateCompanyRequest("Intelisale", "12345678", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", email);

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("Email ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Put_Invalid_RegistrationNumberValue_ThrowsArgumentException(string registrationNumber)
    {
        // Arrange
        var companyId = 11;
        var companyForUpdate = new CreateCompanyRequest("Intelisale", registrationNumber,
            "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "intelisale@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Put(companyId, companyForUpdate));
        Assert.Contains("RegistrationNumber ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Update(companyId, companyForUpdate.Adress, companyForUpdate.FullName,
                companyForUpdate.Email, companyForUpdate.PhoneNumber, companyForUpdate.RegistrationNumber),
            Times.Never);
    }

    [Fact]
    public async Task Put_Invalid_IdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange
        var companyId = 1;
        var companyRequest = new CreateCompanyRequest("Silaris Solutions", "12345678", "Milovana Glišića 12/2, Šabac",
            "0642193578", "silaris@gmail.com");
        _companyServiceMock.Setup(p => p.GetById(companyId))!
            .ReturnsAsync((Company?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(async () =>
            await _companyController.Put(companyId, companyRequest));
        Assert.Contains($"Objekat sa Id-jem {companyId} se ne nalazi u bazi!", ex.Message);
    }
}