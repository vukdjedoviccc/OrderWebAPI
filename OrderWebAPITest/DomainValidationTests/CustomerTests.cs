using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class CustomerTests
{
    #region ValidCustomerCreatedTest

    [Fact]
    public void Valid_Customer_Created()
    {
        // Arrange and act
        var customer = new Customer("Jurija Gagarina14G, Beograd", "0645233699", "silaris@gmail.com", 1);

        // Assert
        Assert.NotNull(customer);
        Assert.NotEmpty(customer.Address);
        Assert.NotEmpty(customer.PhoneNumber);
        Assert.NotEmpty(customer.Email);
        Assert.NotNull(customer.Address);
        Assert.NotNull(customer.PhoneNumber);
        Assert.NotNull(customer.Email);
    }

    #endregion

    #region IdTests

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578", "test@gmail.com", null)]
    public void ArgumentNullException_Thrown_When_Id_Is_Null(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578", "test@gmail.com", -12)]
    public void ArgumentException_Thrown_When_Id_Is_Negative(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578", "test@gmail.com", 0)]
    public void ArgumentException_Thrown_When_Id_Is_0(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    #endregion

    #region AdressTests

    [Theory]
    [InlineData(null, "0652193578", "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_Adress_Is_Null(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("", "0652193578", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_Adress_Is_Empty(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd dsahdlasdasdasjdashdakjeqoiufsabdasalalak", "0652193578", "test@gmail.com",
        12)]
    public void ArgumentException_Thrown_When_Adress_Length_Is_More_Than_40_Characters(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    #endregion

    #region PhoneNumberTests

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", null, "test@gmail.com", 12)]
    public void ArgumentNullException_Thrown_When_PhoneNumber_Is_Null(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_PhoneNumber_Is_Empty(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578123", "test@gmail.com", 12)]
    public void ArgumentException_Thrown_When_PhoneNumber_Length_Is_More_Than_10_Characters(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    #endregion

    #region EmailTests

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578", null, 12)]
    public void ArgumentNullException_Thrown_When_Email_Is_Null(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578", "", 12)]
    public void ArgumentException_Thrown_When_Email_Is_Empty(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    [Theory]
    [InlineData("Jurija Gagarina14G, Beograd", "0652193578123", "test1234567890qwertyutnovnfifzdssdvsusbsusb@gmail.com",
        12)]
    public void ArgumentException_Thrown_When_Email_Length_Is_More_Than_30_Characters(string adress,
        string phoneNumber,
        string email,
        int id)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Customer(adress, phoneNumber, email, id));
    }

    #endregion
}