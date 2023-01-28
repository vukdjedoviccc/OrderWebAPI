using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderWebAPITest.DomainValidationTests
{
    public class OrderTests
    {
        #region ValidorderCreatedTest
        [Fact]
        public void Valid_Order_Created()
        {
            // Arrange and act
            Order.Domain.Model.Order order = new Order.Domain.Model.Order(1, 1, new DateTime(2011, 6, 10), 146890.00M, new List<OrderItem>());

            // Assert
            Assert.NotNull(order);
            Assert.NotNull(order.Date);
            Assert.NotNull(order.OrderItems);
        }
        #endregion

        #region IdTests
        [Theory]
        [InlineData(null, 1, 146890.00)]
        public void ArgumentException_Thrown_When_Id_Is_Null(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }

        [Theory]
        [InlineData(-1, 1, 146890.00)]
        public void ArgumentException_Thrown_When_Id_Is_Negative(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }

        [Theory]
        [InlineData(0, 1, 146890.00)]
        public void ArgumentException_Thrown_When_Id_Is_0(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }
        #endregion

        #region CustomerIdTests
        [Theory]
        [InlineData(1, null, 146890.00)]
        public void ArgumentException_Thrown_When_CustomerId_Is_Null(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }

        [Theory]
        [InlineData(1, -1, 146890.00)]
        public void ArgumentException_Thrown_When_CustomerId_Is_Negative(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }

        [Theory]
        [InlineData(1, 0, 146890.00)]
        public void ArgumentException_Thrown_When_CustomerId_Is_0(int id, int customerId,
            decimal totalAmount)
        {
            // Arrange
            DateTime dt = new DateTime(2011, 6, 10);
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }
        #endregion

        #region DateTests
        [Theory]
        [InlineData(1, 2, 0)]
        public void ArgumentNullException_Thrown_When_Date_Is_Null(int id, int customerId,
            decimal totalAmount)
        {

            DateTime? dt = null;
            List<OrderItem> orderItems = new List<OrderItem>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }
        #endregion

        #region OrderItemsTests
        [Theory]
        [InlineData(1, 2, 0)]
        public void ArgumentNullException_Thrown_When_OrderItems_Is_Null(int id, int customerId,
            decimal totalAmount)
        {

            DateTime? dt = null;
            List<OrderItem> orderItems = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Order.Domain.Model.Order(id, customerId, dt, totalAmount, orderItems));
        }
        #endregion

        #region CalculateTotalAmountTest
        [Fact]
        public void Calculate_Total_Amount_First_Test() 
        {
            // Arrange
            List<OrderItem> orderItems = new List<OrderItem> 
            {   // 27000
                new OrderItem 
                { 
                    Id = 1,
                    Product = new Product { Id = 1, Discount = 10, Name = "Majica", Price = 3000},
                    ProductId = 1,
                    Quantity = 10,
                }, // 8000
                new OrderItem
                {
                    Id = 2,
                    //Amount = 200,
                    Product = new Product { Id = 2, Discount = 20, Name = "Dukserica", Price = 2000},
                    ProductId = 2,
                    Quantity = 5,
                }, // 28000
                new OrderItem
                {
                    Id = 3,
                    //Amount = 1500,
                    Product = new Product { Id = 3, Discount = 30, Name = "Farmerke", Price = 4000},
                    ProductId = 3,
                    Quantity = 10,
                }
            };
            Order.Domain.Model.Order order = new Order.Domain.Model.Order
            {
                Id=1,
                CustomerId = 1,
                Date = DateTime.Now,
                OrderItems = orderItems,
            };
            // Act
            order.CalculateTotalAmount();
            var totalAmount = order.TotalAmount;
            var actual = 63000;

            // Assert
            Assert.Equal(totalAmount, actual);
        }

        [Fact]
        public void Calculate_Total_Amount_Second_Test()
        {
            // Arrange
            List<OrderItem> orderItems = new List<OrderItem>
            {   // 3705
                new OrderItem
                {
                    Id = 1,
                    Product = new Product { Id = 1, Discount = 5, Name = "Naočare", Price = 3900},
                    ProductId = 1,
                    Quantity = 1,
                }, // 22500
                new OrderItem
                {
                    Id = 2,
                    Product = new Product { Id = 2, Discount = 10, Name = "Ranac", Price = 5000},
                    ProductId = 2,
                    Quantity = 5,
                }, // 8160
                new OrderItem
                {
                    Id = 3,
                    Product = new Product { Id = 3, Discount = 15, Name = "Džemper", Price = 4800},
                    ProductId = 3,
                    Quantity = 2,
                }, // 6720
                new OrderItem
                {
                    Id = 4,
                    Product = new Product { Id = 4, Discount = 20, Name = "Kačket", Price = 2100},
                    ProductId = 4,
                    Quantity = 4,
                }, // 2700
                new OrderItem
                {
                    Id = 5,
                    Product = new Product { Id = 5, Discount = 25, Name = "Papuče", Price = 1200},
                    ProductId = 5,
                    Quantity = 3,
                }
            };
            Order.Domain.Model.Order order = new Order.Domain.Model.Order
            {
                Id = 1,
                CustomerId = 1,
                Date = DateTime.Now,
                OrderItems = orderItems,
            };
            // Act
            order.CalculateTotalAmount();
            var totalAmount = order.TotalAmount;
            var actual = 43785;

            // Assert
            Assert.Equal(totalAmount, actual);
        }
        #endregion
    }
}
