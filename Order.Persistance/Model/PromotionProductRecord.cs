namespace Order.Persistance.Model
{
    
    public class PromotionProductRecord
    {
        
        public ProductRecord Product { get; set; }
        
        public PromotionRecord Promotion { get; set; }
       
        public int ProductId { get; set; }
       
        public int PromotionId { get; set; }  
    }
}
