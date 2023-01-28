namespace Order.Domain.Request
{
    
    public class CreateOrderRequest
    {
        
        public DateTime Date { get; set; }

       
        public List<CreateOrderItemRequest> Items { get; set; }

        
        public int CustomerId { get; set; }
    }
}
