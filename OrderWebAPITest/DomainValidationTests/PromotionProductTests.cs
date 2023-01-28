using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests
{
    public class PromotionProductTests
    {
        #region ValidPromotionProductCreatedTest
        [Fact]
        public void Valid_PromotionProduct_Created()
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act
            PromotionProduct promotionProduct = new PromotionProduct(1, 1, product, promotion);

            // Assert
            Assert.NotNull(promotionProduct);
            Assert.NotNull(promotionProduct.Promotion);
            Assert.NotNull(promotionProduct.Product);
        }
        #endregion

        #region ProductIdTests
        [Theory]
        [InlineData(null, 1)]
        public void ArgumentNullException_Thrown_When_ProductId_Is_Null(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }

        [Theory]
        [InlineData(-1, 1)]
        public void ArgumentNullException_Thrown_When_ProductId_Is_Negative(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }

        [Theory]
        [InlineData(0, 1)]
        public void ArgumentNullException_Thrown_When_ProductId_Is_0(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }
        #endregion

        #region PromotionIdTests
        [Theory]
        [InlineData(1, null)]
        public void ArgumentNullException_Thrown_When_PromotionId_Is_Null(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }

        [Theory]
        [InlineData(1, -1)]
        public void ArgumentNullException_Thrown_When_PromotionId_Is_Negative(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }

        [Theory]
        [InlineData(1, 0)]
        public void ArgumentNullException_Thrown_When_PromotionId_Is_0(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }
        #endregion

        #region ProductTests
        [Theory]
        [InlineData(1, 1)]
        public void ArgumentNullException_Thrown_When_Product_Is_Null(int productId, int promotionId)
        {
            // Arrange
            Product? product = null;
            Promotion promotion = new Promotion(1, "Zimska", 17);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }
        #endregion

        #region PromotionTests
        [Theory]
        [InlineData(1, 1)]
        public void ArgumentNullException_Thrown_When_Promotion_Is_Null(int productId, int promotionId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);
            Promotion? promotion = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new PromotionProduct(productId, promotionId, product, promotion));
        }
        #endregion
    }
}
