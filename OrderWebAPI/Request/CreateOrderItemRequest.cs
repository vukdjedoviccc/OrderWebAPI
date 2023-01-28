namespace Order.Domain.Request
{
    
    public class CreateOrderItemRequest
    {
        
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
    }
}
