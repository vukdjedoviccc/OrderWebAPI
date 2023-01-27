using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
   
    public class Stock
    {
        private int _id;
        private int _productId;
        private int _quantity;

        
        public Stock()
        {

        }

        
        public Stock(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        
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
