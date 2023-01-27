namespace Order.Persistance.Model
{
    
    public class OrderItemRecord
    {
        
        public int Id { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Amount { get; set; }
       
        public ProductRecord Product { get; set; }
        
        public int ProductId { get; set; }
        
        public int OrderId { get; set; }
        
        public OrderRecord Order { get; set; }
    }
}
