using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests
{
    public class OrderItemTests
    {
        #region ValidorderItemCreatedTest
        [Fact]
        public void Valid_OrderItem_Created()
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act
            OrderItem orderItem = new OrderItem(1, 12, 5480, 7, product);

            // Assert
            Assert.NotNull(orderItem);
            Assert.NotNull(orderItem.Product);
        }
        #endregion

        #region IdTests
        [Theory]
        [InlineData(null, 12, 6700.88, 1)]
        public void ArgumentException_Thrown_When_Id_Is_Null(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(-1, 12, 6700.88, 1)]
        public void ArgumentException_Thrown_When_Id_Is_Negative(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(0, 12, 6700.88, 1)]
        public void ArgumentException_Thrown_When_Id_Is_0(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }
        #endregion

        #region QuantityTests
        [Theory]
        [InlineData(1, -12, 6700.88, 1)]
        public void ArgumentException_Thrown_When_Quantity_Is_Negative(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(1, 0, 6700.88, 1)]
        public void ArgumentException_Thrown_When_Quantity_Is_0(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }
        #endregion

        #region AmountTests
        [Theory]
        [InlineData(1, 12, -6700.88, 1)]
        public void ArgumentException_Thrown_When_Amount_Is_Negative(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(1, 20, 0, 1)]
        public void ArgumentException_Thrown_When_Amount_Is_0(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }
        #endregion

        #region ProductIdTests
        [Theory]
        [InlineData(1, 12, 6700.88, null)]
        public void ArgumentException_Thrown_When_ProductId_Is_Null(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(1, 12, 6700.88, -1)]
        public void ArgumentException_Thrown_When_ProductId_Is_Negative(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
        }

        [Theory]
        [InlineData(1, 12, 6700.88, 0)]
        public void ArgumentException_Thrown_When_ProductId_Is_0(int id, int quantity, decimal amount, int productId)
        {
            // Arrange
            Product product = new Product(1, "Jakna", 8799, 17);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, quantity, amount, productId, product));
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
    }
}
