using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using OrderWebAPI.Request;
using Xunit;

namespace OrderWebAPITest.ControllersTests.CompanyControllerTests;

public class PostTests
{
    private readonly CompanyController _companyController;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public PostTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task Post_ValidCompany_ShouldAddCompany()
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest("Silaris Solutions", "12345678", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "silaris@gmail.com");

        // Act
        await _companyController.Post(companyRequest);

        // Assert
        _companyServiceMock.Verify(p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber,
            companyRequest.Adress,
            companyRequest.PhoneNumber, companyRequest.Email), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_FullNameValue_ShouldThrowsArgumentException(string fullName)
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest(fullName, "12345678", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "silaris@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Post(companyRequest));
        Assert.Contains("FullName ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber, companyRequest.Adress,
                companyRequest.PhoneNumber, companyRequest.Email),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_RegistrationNumberValue_ShouldThrowsArgumentException(string registrationNumber)
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest("Intelisale", registrationNumber, "Dragojla Lazića 18/1, Valjevo",
            "0655130477", "silaris@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Post(companyRequest));
        Assert.Contains("RegistrationNumber ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber, companyRequest.Adress,
                companyRequest.PhoneNumber, companyRequest.Email),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_AddressValue_ShouldThrowsArgumentException(string address)
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest("Intelisale", "12345678", address,
            "0655130477", "silaris@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Post(companyRequest));
        Assert.Contains("Address ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber, companyRequest.Adress,
                companyRequest.PhoneNumber, companyRequest.Email),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_PhoneNumberValue_ShouldThrowsArgumentException(string phoneNumber)
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest("Intelisale", "12345678", "Dragojla Lazića 18/1, Valjevo",
            phoneNumber, "silaris@gmail.com");

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Post(companyRequest));
        Assert.Contains("PhoneNumber ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber, companyRequest.Adress,
                companyRequest.PhoneNumber, companyRequest.Email),
            Times.Never);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task Post_Invalid_EmailValue_ShouldThrowsArgumentException(string email)
    {
        // Arrange
        var companyRequest = new CreateCompanyRequest("Intelisale", "12345678", "Dragojla Lazića 18/1, Valjevo",
            "0655130477", email);

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(
            () => _companyController.Post(companyRequest));
        Assert.Contains("Email ne može biti null ili prazan string!", ex.Message);
        _companyServiceMock.Verify(
            p => p.Add(companyRequest.FullName, companyRequest.RegistrationNumber, companyRequest.Adress,
                companyRequest.PhoneNumber, companyRequest.Email),
            Times.Never);
    }
}