using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
    /// <summary>
    /// Klasa domena koja se odnosi na skladište
    /// </summary>
    public class Stock
    {
        private int _id;
        private int _productId;
        private int _quantity;

        /// <summary>
        /// Bezparametarski konstruktor klase Stock 
        /// </summary>
        public Stock()
        {

        }

        /// <summary>
        /// Parametarski konstruktor klase Customer 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public Stock(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Id reda u tabeli koji se odnosi na proizvod na skladištu
        /// </summary>
        public int Id 
        {
            get
            {
                return _id;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _id = value;
            }
        }

        /// <summary>
        /// Id proizvoda na skladištu
        /// </summary>
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _productId = value;
            }
        }

        /// <summary>
        /// Količina određenog proizvoda na skladištu 
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                Validations.NumberNotNegativeOrEqualTo0(value);
                _quantity = value;
            }
        }
    }
}
