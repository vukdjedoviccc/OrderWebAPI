using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    /// <summary>
    /// Klasa koja se odnosi na naručivanje
    /// </summary>
    public class Order
    {
        private int _id;
        private int _customerId;
        private DateTime? _date;
        private List<OrderItem>? _orderItems;

        /// <summary>
        /// Bezparametarski konstruktor klase Order 
        /// </summary>
        public Order()
        {
             
        }

        /// <summary>
        /// Parametarski konstruktor klase Order 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerId"></param>
        /// <param name="date"></param>
        /// <param name="totalAmount"></param>
        /// <param name="orderItems"></param>
        public Order(int id, int customerId, DateTime? date, decimal totalAmount, List<OrderItem>? orderItems)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
            TotalAmount = totalAmount;
            OrderItems = orderItems;
        }

        /// <summary>
        /// Id narudžbine
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
        /// Id kupca
        /// </summary>
        public int CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _customerId = value;
            }
        }

        /// <summary>
        /// Vreme narudžbine
        /// </summary>
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                Validations.NotNull(value);
                _date = value;
            }
        }

        /// <summary>
        /// Ukupan iznos narudžbine
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Lista stavki narudžbine
        /// </summary>
        public List<OrderItem>? OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                Validations.NotNull(value);
                _orderItems = value;
            }
        }

        /// <summary>
        /// Metoda koja služi za računanje ukupnog iznosa narudžbine
        /// </summary>
        public void CalculateTotalAmount()
        {
            foreach (var item in OrderItems)
            {
                var itemAmount = 0M;
                
                var discount = item.Product.Discount ?? 100; 
                itemAmount += item.Quantity * (item.Product.Price - (item.Product.Price * (discount / 100)));
                item.Amount = itemAmount;
            }
            TotalAmount = 0M;
            foreach (var item in OrderItems)
            {
                TotalAmount += item.Amount;
            }
        }
    }
}
