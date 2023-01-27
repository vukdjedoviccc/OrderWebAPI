namespace Order.Persistance.Model
{
    
    public class OrderRecord
    {
        
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        
        public DateTime? Date { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public List<OrderItemRecord> OrderItems { get; set; }
        
        public CustomerRecord Customer { get; set; }

    }
}
