using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    
    public class Promotion
    {
        private int _id;
        private string _name;
        private decimal _discount;
        private DateTime _fromDate;
        private DateTime _toDate;
        private List<Product> _products;

        
        public Promotion()
        {

        }

       
        public Promotion(int id, string name, decimal discount)
        {
            Id = id;
            Name = name;
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
                Validations.StringLengthLessThanOrEqualTo(value, 30);
                _name = value;
            }
        }

        
        public decimal Discount
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

       
        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                Validations.NotNull(value);
                _fromDate = value;
            }
        }

        
        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                Validations.NotNull(value);
                _toDate = value;
            }
        }

        
        public List<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                Validations.NotNull(value);
                _products = value;
            }
        }
    }
}
