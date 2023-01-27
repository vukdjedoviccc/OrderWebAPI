using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    
    public class Order
    {
        private int _id;
        private int _customerId;
        private DateTime? _date;
        private List<OrderItem>? _orderItems;

        
        public Order()
        {
             
        }

       
        public Order(int id, int customerId, DateTime? date, decimal totalAmount, List<OrderItem>? orderItems)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
            TotalAmount = totalAmount;
            OrderItems = orderItems;
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

        
        public decimal TotalAmount { get; set; }

        
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
