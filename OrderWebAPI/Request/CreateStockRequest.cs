namespace Order.Domain.Request
{
    
    public class CreateStockRequest
    {
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}
