using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    /// <summary>
    /// Klasa domena koja se odnosi na promocije
    /// </summary>
    public class Promotion
    {
        private int _id;
        private string _name;
        private decimal _discount;
        private DateTime _fromDate;
        private DateTime _toDate;
        private List<Product> _products;

        /// <summary>
        /// Bezparametarski konstruktor klase Promotion 
        /// </summary>
        public Promotion()
        {

        }

        /// <summary>
        /// Parametarski konstruktor klase Customer 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="discount"></param>
        public Promotion(int id, string name, decimal discount)
        {
            Id = id;
            Name = name;
            Discount = discount;
        }

        /// <summary>
        /// Parametarski konstruktor klase Customer 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="registrationNumber"></param>
        /// <param name="adress"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// 

        /// <summary>
        /// Id promocije
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
        /// Naziv promocije
        /// </summary>
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

        /// <summary>
        /// Popust promocije
        /// </summary>
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

        /// <summary>
        /// Datum početka promocije
        /// </summary>
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

        /// <summary>
        /// Datum završetka promocije
        /// </summary>
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

        /// <summary>
        /// Lista proizvoda
        /// </summary>
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
