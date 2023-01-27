using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    
    public class Product
    {
        private int _id;
        private string _name;
        private decimal _price;
        private decimal? _discount;

        
        public Product()
        {

        }

        
        public Product(int id, string name, decimal price, decimal? discount)
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
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

        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 25);
                _name = value;
            }
        }

        
        public decimal Price 
        {
            get
            {
                return _price;
            }
            set
            {
                Validations.NumberNotNegativeOrEqualTo0(value);
                _price = value;
            }
        }

        
        public decimal? Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                Validations.NumberNotNegativeOrEqualTo0(value);
                _discount = value;
            }
        }
    }
}
