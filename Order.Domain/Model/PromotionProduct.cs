using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    
    public class PromotionProduct
    {
        private int _productId;
        private int _promotionId;
        private Product _product;
        private Promotion _promotion;

       
        public PromotionProduct()
        {

        }

        
        public PromotionProduct(int productId, int promotionId, Product product, Promotion promotion)
        {
            ProductId = productId;
            PromotionId = promotionId;
            Product = product;
            Promotion = promotion;
        }

        
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                Validations.NotNull(value);
                _product = value;
            }
        }

        
        public Promotion Promotion
        {
            get
            {
                return _promotion;
            }
            set
            {
                Validations.NotNull(value);
                _promotion = value;
            }
        }

        
        public int ProductId 
        {
            get
            {
                return _productId;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _productId = value;
            }
        }
        
        public int PromotionId
        {
            get
            {
                return _promotionId;
            }
            set
            {
                Validations.NotNull(value);
                Validations.NumberNotNegativeOrEqualTo0(value);
                _promotionId = value;
            }
        }
    }
}
