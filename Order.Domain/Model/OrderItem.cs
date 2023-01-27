using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    
    public class OrderItem
    {
        private int _id;
        private int _quantity;
        private decimal _amount;
        private int _productId;
        private Product _product;

        
        public OrderItem()
        {

        }

        
        public OrderItem(int id, int quantity, decimal amount, int productId, Product product)
        {
            Id = id;
            Quantity = quantity;
            Amount = amount;
            ProductId = productId;
            Product = product;
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
       

        public decimal Amount 
        {
            get
            {
                return _amount;
            }
            set
            {
                Validations.NumberNotNegativeOrEqualTo0(value);
                _amount = value;
            }
        }

        
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                Validations.NotNull(value);
                _product = value;
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

    }
}
