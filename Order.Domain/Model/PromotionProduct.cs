using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa domena koja se odnosi na proizvode koji imaju promocije
/// </summary>
public class PromotionProduct
{
    private Product _product;
    private int _productId;
    private Promotion _promotion;
    private int _promotionId;

    /// <summary>
    ///     Bezparametarski konstruktor klase PromotionProduct
    /// </summary>
    public PromotionProduct()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase PromotionProduct
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="promotionId"></param>
    /// <param name="product"></param>
    /// <param name="promotion"></param>
    public PromotionProduct(int productId, int promotionId, Product product, Promotion promotion)
    {
        ProductId = productId;
        PromotionId = promotionId;
        Product = product;
        Promotion = promotion;
    }

    /// <summary>
    ///     Objekat proizvoda
    /// </summary>
    public Product Product
    {
        get => _product;
        set
        {
            Validations.NotNull(value);
            _product = value;
        }
    }

    /// <summary>
    ///     Objekat promocije
    /// </summary>
    public Promotion Promotion
    {
        get => _promotion;
        set
        {
            Validations.NotNull(value);
            _promotion = value;
        }
    }

    /// <summary>
    ///     Id proizvoda
    /// </summary>
    public int ProductId
    {
        get => _productId;
        set
        {
            Validations.NotNull(value);
            Validations.NumberNotNegativeOrEqualTo0(value);
            _productId = value;
        }
    }

    /// <summary>
    ///     Id promocije
    /// </summary>
    public int PromotionId
    {
        get => _promotionId;
        set
        {
            Validations.NotNull(value);
            Validations.NumberNotNegativeOrEqualTo0(value);
            _promotionId = value;
        }
    }
}