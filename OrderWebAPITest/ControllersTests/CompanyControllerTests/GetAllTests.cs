using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.CompanyControllerTests;

public class GetAllTests
{
    private readonly CompanyController _companyController;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public GetAllTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK()
    {
        // Arrange
        _companyServiceMock.Setup(p => p.GetAll())
            .ReturnsAsync(new List<Company>
            {
                new()
                {
                    FullName = "Silaris Solutions", RegistrationNumber = "01234567",
                    Adress = "Dragojla Lazića 18/1, Valjevo",
                    Email = "silaris@gmail.com", PhoneNumber = "0655130477", Id = 1
                },
                new()
                {
                    FullName = "Intelisale", RegistrationNumber = "12345678", Adress = "Cara Dušaana 12, Loznica",
                    Email = "intelisale@gmail.com", PhoneNumber = "0645233699", Id = 2
                },
                new()
                {
                    FullName = "GoPro", RegistrationNumber = "23456789", Adress = "Vojovde Mišića 142, Beograd",
                    Email = "gopro@gmail.com", PhoneNumber = "0642193758", Id = 3
                }
            });

        // Act
        var response = await _companyController.GetAll();

        // Assert
        var resultValue = response.Value;
        Assert.NotNull(response.Value);
        Assert.IsType<List<Company>>(resultValue);
        var companies = resultValue;
        Assert.Equal(3, companies?.Count);
        Assert.Equal(1, companies?.ToArray()[0].Id);
        Assert.Equal("Silaris Solutions", companies?.ToArray()[0].FullName);
        Assert.Equal("01234567", companies?.ToArray()[0].RegistrationNumber);
        Assert.Equal("Dragojla Lazića 18/1, Valjevo", companies?.ToArray()[0].Adress);
        Assert.Equal("silaris@gmail.com", companies?.ToArray()[0].Email);
        Assert.Equal("0655130477", companies?.ToArray()[0].PhoneNumber);
        Assert.Equal(2, companies?.ToArray()[1].Id);
        Assert.Equal("Intelisale", companies?.ToArray()[1].FullName);
        Assert.Equal("12345678", companies?.ToArray()[1].RegistrationNumber);
        Assert.Equal("Cara Dušaana 12, Loznica", companies?.ToArray()[1].Adress);
        Assert.Equal("intelisale@gmail.com", companies?.ToArray()[1].Email);
        Assert.Equal("0645233699", companies?.ToArray()[1].PhoneNumber);
        Assert.Equal(3, companies?.ToArray()[2].Id);
        Assert.Equal("GoPro", companies?.ToArray()[2].FullName);
        Assert.Equal("23456789", companies?.ToArray()[2].RegistrationNumber);
        Assert.Equal("Vojovde Mišića 142, Beograd", companies?.ToArray()[2].Adress);
        Assert.Equal("gopro@gmail.com", companies?.ToArray()[2].Email);
        Assert.Equal("0642193758", companies?.ToArray()[2].PhoneNumber);
    }

    [Fact]
    public async Task GetAll_EmptyCompanyList_ReturnsNullReferenceException()
    {
        // Arrange
        _companyServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Company>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _companyController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat kompanije!", ex.Message);
    }
}