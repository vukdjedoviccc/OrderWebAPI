namespace Order.Persistance.Model
{
    
    public class ProductRecord
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
       
        public List<OrderItemRecord> OrderItems { get; set; }
        
        public List<PromotionProductRecord> PromotionProducts { get; set; }
        
        public StockRecord Stock { get; set; }
    }
}
