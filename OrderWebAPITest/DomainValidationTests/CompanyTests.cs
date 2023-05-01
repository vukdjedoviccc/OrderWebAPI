using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class CompanyTests
{
    #region ValidCompanyCreatedTest

    [Fact]
    public void Valid_Company_Created()
    {
        // Arrange and act
        var company = new Company("Silaris Solutions", "91345287", "Jurija Gagarina14G, Beograd", "0645233699",
            "silaris@gmail.com", 1);

        // Assert
        Assert.NotNull(company);
        Assert.NotEmpty(company.FullName);
        Assert.NotEmpty(company.RegistrationNumber);
        Assert.NotEmpty(company.Address);
        Assert.NotEmpty(company.PhoneNumber);
        Assert.NotEmpty(company.Email);
        Assert.NotNull(company.FullName);
        Assert.NotNull(company.RegistrationNumber);
        Assert.NotNull(company.Address);
        Assert.NotNull(company.PhoneNumber);
        Assert.NotNull(company.Email);
    }

    #endregion

    #region FullNameTests

    [Theory]
    [InlineData(null, "12345678", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_FullName_Is_Null(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
            new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("", "12345678", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_FullName_Is_Empty(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Silaris Solutionsqwertzuioplskdhdkksbssdshdhdhfhiwdjqvdqwdqwdvjdqwwiohffdbfwefofwefiwefhwiefwefhfewfw",
        "123456789", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_FullName_Length_Is_More_Than_50_Characters(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    #endregion

    #region RegistrationNumberTests

    [Theory]
    [InlineData("Silaris Solutions", null, "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_RegistrationNumber_Is_Null(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() =>
            new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Silaris Solutions", "", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_RegistrationNumber_Is_Empty(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Silaris Solutions", "123456789", "Vojvode Stepe 174, Beograd", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_RegistrationNumber_Length_Is_More_Than_8_Characters(string fullName,
        string registrationNumber,
        string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(
            () => new Company(fullName, registrationNumber, adress, phoneNumber, email, id));
    }

    #endregion
}