using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.CompanyControllerTests;

public class GetByIdTests
{
    private readonly CompanyController _companyController;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public GetByIdTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task GetById_OK()
    {
        // Arrange
        var companyId = 1;
        _companyServiceMock.Setup(p => p.GetById(companyId)).ReturnsAsync(new Company
        {
            FullName = "Silaris Solutions", RegistrationNumber = "01234567",
            Adress = "Dragojla Lazića 18/1, Valjevo",
            Email = "silaris@gmail.com", PhoneNumber = "0655130477", Id = 1
        });

        // Act
        var response = _companyController.GetById(companyId);

        // Assert
        _companyServiceMock.Verify(s => s.GetById(companyId), Times.Once());
        Assert.Equal(companyId, response.Result.Value?.Id);
        Assert.Equal("Silaris Solutions", response.Result.Value?.FullName);
        Assert.Equal("01234567", response.Result.Value?.RegistrationNumber);
        Assert.Equal("Dragojla Lazića 18/1, Valjevo", response.Result.Value?.Adress);
        Assert.Equal("silaris@gmail.com", response.Result.Value?.Email);
        Assert.Equal("0655130477", response.Result.Value?.PhoneNumber);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task GetById_InvalidCompanyIdValue_ThrowsArgumentException(int companyId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _companyController.GetById(companyId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _companyServiceMock.Verify(s => s.GetById(companyId), Times.Never());
    }

    [Fact]
    public async Task GetById_InvalidIdDoesntExist_ThrowsNullReferenceException()
    {
        // Arrange

        // Act and Assert
        var companyId = 115;
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _companyController.GetById(companyId));
        Assert.Contains($"Objekat sa Id-jem {companyId} se ne nalazi u bazi!", ex.Message);
    }
}