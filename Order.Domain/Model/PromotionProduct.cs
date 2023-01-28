using Order.Domain.DomainValidations;

namespace Order.Domain.Model
{
    /// <summary>
    /// Klasa domena koja se odnosi na proizvode koji imaju promocije
    /// </summary>
    public class PromotionProduct
    {
        private int _productId;
        private int _promotionId;
        private Product _product;
        private Promotion _promotion;

        /// <summary>
        /// Bezparametarski konstruktor klase PromotionProduct 
        /// </summary>
        public PromotionProduct()
        {

        }

        /// <summary>
        /// Parametarski konstruktor klase Customer 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="promotionId"></param>
        /// <param name="adress"></param>
        /// <param name="phoneNumber"></param>
        public PromotionProduct(int productId, int promotionId, Product product, Promotion promotion)
        {
            ProductId = productId;
            PromotionId = promotionId;
            Product = product;
            Promotion = promotion;
        }

        /// <summary>
        /// Objekat proizvoda
        /// </summary>
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

        /// <summary>
        /// Objekat promocije
        /// </summary>
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

        /// <summary>
        /// Id proizvoda
        /// </summary>
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
        /// <summary>
        /// Id promocije
        /// </summary>
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
