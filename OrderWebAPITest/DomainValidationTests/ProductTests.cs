using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class ProductTests
{
    #region ValidProductCreatedTest

    [Fact]
    public void Valid_Product_Created()
    {
        // Arrange and act
        var product = new Product(1, "Jakna", 5550, 14);

        // Assert
        Assert.NotNull(product);
        Assert.NotEmpty(product.Name);
        Assert.NotNull(product.Name);
    }

    #endregion

    #region ProductIdTests

    [Theory]
    [InlineData(null, "Jakna", 6700.88, 22)]
    public void ArgumentException_Thrown_When_Id_Is_Null(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(-1, "Jakna", 6700.88, 22)]
    public void ArgumentException_Thrown_When_Id_Is_Negative(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(0, "Jakna", 6700.88, 22)]
    public void ArgumentNullException_Thrown_When_Id_Is_0(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    #endregion

    #region NameTests

    [Theory]
    [InlineData(1, null, 6700.88, 22)]
    public void ArgumentNullException_Thrown_When_Name_Is_Null(int id, string name, decimal price, decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(1, "", 6700.88, 22)]
    public void ArgumentException_Thrown_When_Name_Is_Empty(int id, string name, decimal price, decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(1, "Jakna qwertzuiopšđćčlkjhgf", 6700.88, 22)]
    public void ArgumentException_Thrown_When_Name_Length_Is_More_Than_25_CharactersEmpty(int id, string name,
        decimal price, decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    #endregion

    #region PriceTests

    [Theory]
    [InlineData(1, "Jakna", -6700.88, 22)]
    public void ArgumentException_Thrown_When_Price_Is_Negative(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(1, "Jakna", 0, 22)]
    public void ArgumentNullException_Thrown_When_Price_Is_0(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    #endregion

    #region DiscountTests

    [Theory]
    [InlineData(1, "Jakna", 6700.88, -22)]
    public void ArgumentException_Thrown_When_Discount_Is_Negative(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    [Theory]
    [InlineData(1, "Jakna", 6700.88, 0)]
    public void ArgumentNullException_Thrown_When_Discount_Is_0(int id, string name, decimal price, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Product(id, name, price, discount));
    }

    #endregion
}