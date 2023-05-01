using System;
using Order.Domain.Model;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests;

public class PromotionTests
{
    #region ValidPromotionCreatedTest

    [Fact]
    public void Valid_Promotion_Created()
    {
        // Arrange and act
        var promotion = new Promotion(1, "Zimska", 14);

        // Assert
        Assert.NotNull(promotion);
        Assert.NotEmpty(promotion.Name);
        Assert.NotNull(promotion.Name);
    }

    #endregion

    #region PromotionIdTests

    [Theory]
    [InlineData(null, "Zimska", 22)]
    public void ArgumentException_Thrown_When_Id_Is_Null(int id, string name, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    [Theory]
    [InlineData(-1, "Zimska", 22)]
    public void ArgumentException_Thrown_When_Id_Is_Negative(int id, string name, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    [Theory]
    [InlineData(0, "Zimska", 22)]
    public void ArgumentNullException_Thrown_When_Id_Is_0(int id, string name, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    #endregion

    #region NameTests

    [Theory]
    [InlineData(1, null, 22)]
    public void ArgumentNullException_Thrown_When_Name_Is_Null(int id, string name, decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new Promotion(id, name, discount));
    }

    [Theory]
    [InlineData(1, "", 22)]
    public void ArgumentNullException_Thrown_When_Name_Is_Empty(int id, string name, decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    [Theory]
    [InlineData(1, "Specijalna zimska promocija nad promocijama", 22)]
    public void ArgumentNullException_Thrown_When_Name_Length_Is_More_Than_30_Characters(int id, string name,
        decimal discount)
    {
        // Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    #endregion

    #region DiscountTests

    [Theory]
    [InlineData(1, "Zimska", -22)]
    public void ArgumentException_Thrown_When_Discount_Is_Negative(int id, string name, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    [Theory]
    [InlineData(1, "Zimska", 0)]
    public void ArgumentException_Thrown_When_Discount_Is_0(int id, string name, decimal discount)
    {
        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Promotion(id, name, discount));
    }

    #endregion
}