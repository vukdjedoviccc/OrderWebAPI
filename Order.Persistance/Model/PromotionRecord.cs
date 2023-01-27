namespace Order.Persistance.Model
{
    
    public class PromotionRecord
    {
       
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public decimal Discount { get; set; }
       
        public DateTime FromDate { get; set; }
        
        public DateTime ToDate { get; set; }
        
        public List<PromotionProductRecord> PromotionProducts { get; set; }
    }
}
