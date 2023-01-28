namespace Order.Domain.Request
{
    
    public class CreatePromotionRequest
    {
        
        public string Name { get; set; }
       
        public decimal Discount { get; set; }
        
        public DateTime FromDate { get; set; }
       
        public DateTime ToDate { get; set; }
       
        public List<int> ProductIds { get; set; } 
    }
}
