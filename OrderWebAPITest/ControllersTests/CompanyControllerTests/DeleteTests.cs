using System;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.CompanyControllerTests;

public class DeleteTests
{
    private readonly CompanyController _companyController;
    private readonly Mock<ICompanyService> _companyServiceMock;

    public DeleteTests()
    {
        _companyServiceMock = new Mock<ICompanyService>();
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task Delete_OK()
    {
        // Arrange
        var companyId = 1;
        _companyServiceMock.Setup(p => p.Delete(companyId)).Returns(Task.CompletedTask);

        // Act
        await _companyController.Delete(companyId);

        // Assert
        _companyServiceMock.Verify(s => s.Delete(companyId), Times.Once());
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Delete_InvalidIdZeroValue_ThrowsArgumentException(int companyId)
    {
        // Arrange

        // Act and Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _companyController.Delete(companyId));
        Assert.Contains("Id ne može biti negativan broj ili jednak nuli!", ex.Message);
        _companyServiceMock.Verify(s => s.Delete(companyId), Times.Never());
    }
}