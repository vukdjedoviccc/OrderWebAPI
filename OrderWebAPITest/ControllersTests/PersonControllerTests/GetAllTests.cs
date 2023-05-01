using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Controllers;
using Xunit;

namespace OrderWebAPITest.ControllersTests.PersonControllerTests;

public class GetAllTests
{
    private readonly PersonController _personController;
    private readonly Mock<IPersonService> _personServiceMock;

    public GetAllTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personController = new PersonController(_personServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_OK()
    {
        // Arrange
        _personServiceMock.Setup(p => p.GetAll())
            .ReturnsAsync(new List<Person>
            {
                new()
                {
                    Id = 1, FirstName = "Vuk", LastName = "Đedović", Address = "Dragojla Lazića 18/1, Valjevo",
                    Email = "vukdjedovic@gmail.com", PhoneNumber = "0655130477"
                },
                new()
                {
                    Id = 2, FirstName = "Jakov", LastName = "Ignjatović", Address = "Vojvode Putnika 14a, Kruševac",
                    Email = "jignjatovic@gmail.com", PhoneNumber = "0637688933"
                },
                new()
                {
                    Id = 3, FirstName = "Anđela", LastName = "Jović", Address = "Prešernova 144b, Beograd",
                    Email = "andjelaj@gmail.com", PhoneNumber = "0667329388"
                }
            });

        // Act
        var response = await _personController.GetAll();

        // Assert
        var resultValue = response.Value;
        Assert.NotNull(response.Value);
        Assert.IsType<List<Person>>(resultValue);
        var persons = (List<Person>?)resultValue;
        Assert.Equal(3, persons?.Count);
        Assert.Equal(1, persons?.ToArray()[0].Id);
        Assert.Equal("Vuk", persons?.ToArray()[0].FirstName);
        Assert.Equal("Đedović", persons?.ToArray()[0].LastName);
        Assert.Equal("Dragojla Lazića 18/1, Valjevo", persons?.ToArray()[0].Address);
        Assert.Equal("vukdjedovic@gmail.com", persons?.ToArray()[0].Email);
        Assert.Equal("0655130477", persons?.ToArray()[0].PhoneNumber);
        Assert.Equal(2, persons?.ToArray()[1].Id);
        Assert.Equal("Jakov", persons?.ToArray()[1].FirstName);
        Assert.Equal("Ignjatović", persons?.ToArray()[1].LastName);
        Assert.Equal("Vojvode Putnika 14a, Kruševac", persons?.ToArray()[1].Address);
        Assert.Equal("jignjatovic@gmail.com", persons?.ToArray()[1].Email);
        Assert.Equal("0637688933", persons?.ToArray()[1].PhoneNumber);
        Assert.Equal(3, persons?.ToArray()[2].Id);
        Assert.Equal("Anđela", persons?.ToArray()[2].FirstName);
        Assert.Equal("Jović", persons?.ToArray()[2].LastName);
        Assert.Equal("Prešernova 144b, Beograd", persons?.ToArray()[2].Address);
        Assert.Equal("andjelaj@gmail.com", persons?.ToArray()[2].Email);
        Assert.Equal("0667329388", persons?.ToArray()[2].PhoneNumber);
    }

    [Fact]
    public async Task GetAll_EmptyPersonList_NullReferenceException()
    {
        // Arrange
        _personServiceMock.Setup(p => p.GetAll())!
            .ReturnsAsync((List<Person>?)null);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() => _personController.GetAll());
        Assert.Contains("U bazi se ne nalazi ni jedan objekat osobe!", ex.Message);
    }
}