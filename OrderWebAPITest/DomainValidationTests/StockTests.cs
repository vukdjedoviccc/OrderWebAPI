using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class StockTests
{
    #region ValidStockCreatedTest

    [Fact]
    public void Valid_Company_Created()
    {
        // Arrange and act
        var stock = new Stock(1, 1, 15);

        // Assert
        Assert.NotNull(stock);
    }

    #endregion

    #region IdTests

    [Theory]
    [InlineData(null, 1, 15)]
    public void ArgumentNullException_Thrown_When_Id_Is_Null(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    [Theory]
    [InlineData(-12, 1, 15)]
    public void ArgumentException_Thrown_When_Id_Is_Negative(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    [Theory]
    [InlineData(0, 1, 15)]
    public void ArgumentException_Thrown_When_Id_Is_0(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    #endregion

    #region ProductIdTests

    [Theory]
    [InlineData(1, null, 15)]
    public void ArgumentNullException_Thrown_When_ProductId_Is_Null(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    [Theory]
    [InlineData(1, -1, 15)]
    public void ArgumentException_Thrown_When_ProductId_Is_Negative(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    [Theory]
    [InlineData(1, 0, 15)]
    public void ArgumentException_Thrown_When_ProductId_Is_0(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    #endregion

    #region QuantityTests

    [Theory]
    [InlineData(1, 1, -15)]
    public void ArgumentException_Thrown_When_Quantity_Is_Negative(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    [Theory]
    [InlineData(1, 1, 0)]
    public void ArgumentException_Thrown_When_Quantity_Is_0(int id, int productId, int quantity)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Stock(id, productId, quantity));
    }

    #endregion
}