using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class PersonTests
{
    #region ValidPersonCreatedTest

    [Fact]
    public void Valid_Person_Created()
    {
        // Arrange and act
        var person = new Person("Vuk", "Đedović", "Jurija Gagarina14G, Beograd", "0645233699", "silaris@gmail.com", 1);

        // Assert
        Assert.NotNull(person);
        Assert.NotEmpty(person.FirstName);
        Assert.NotEmpty(person.LastName);
        Assert.NotEmpty(person.Address);
        Assert.NotEmpty(person.PhoneNumber);
        Assert.NotEmpty(person.Email);
        Assert.NotNull(person.FirstName);
        Assert.NotNull(person.LastName);
        Assert.NotNull(person.Address);
        Assert.NotNull(person.PhoneNumber);
        Assert.NotNull(person.Email);
    }

    #endregion

    #region FirstNameTests

    [Theory]
    [InlineData(null, "Đedović", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_FirstName_Is_Null(string firstName, string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("", "Đedović", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_FirstName_Is_Empty(string firstName, string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Vukqiwuebdudjdosususus", "Đedović", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_FirstName_Length_Is_More_Than_15_Characters(string firstName,
        string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    #endregion

    #region LastNameTests

    [Theory]
    [InlineData("Vuk", null, "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_LastName_Is_Null(string firstName, string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Vuk", "", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_LastName_Is_Empty(string firstName, string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Vuk", "Đedovićqwertzuijkdmnccncbk", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_LastName_Length_Is_More_Than_15_Characters(string firstName,
        string lastName,
        string adress, string phoneNumber, string email, int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Person(firstName, lastName, adress, phoneNumber, email, id));
    }

    #endregion
}