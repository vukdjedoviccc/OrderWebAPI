using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na stavke narudžbine
/// </summary>
public class OrderItem
{
    private decimal _amount;
    private int _id;
    private Product _product;
    private int _productId;
    private int _quantity;

    /// <summary>
    ///     Bezparametarski konstruktor klase OrderItem
    /// </summary>
    public OrderItem()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase OrderItem
    /// </summary>
    /// <param name="id"></param>
    /// <param name="quantity"></param>
    /// <param name="amount"></param>
    /// <param name="productId"></param>
    /// <param name="product"></param>
    public OrderItem(int id, int quantity, decimal amount, int productId, Product product)
    {
        Id = id;
        Quantity = quantity;
        Amount = amount;
        ProductId = productId;
        Product = product;
    }

    /// <summary>
    ///     Id stavke narudžbine
    /// </summary>
    public int Id
    {
        get => _id;
        set
        {
            Validations.NotNull(value);
            Validations.NumberNotNegativeOrEqualTo0(value);
            _id = value;
        }
    }

    /// <summary>
    ///     Količina stavke narudžbine
    /// </summary>
    public int Quantity
    {
        get => _quantity;
        set
        {
            Validations.NumberNotNegativeOrEqualTo0(value);
            _quantity = value;
        }
    }

    /// <summary>
    ///     Iznos stavke narudžbine
    /// </summary>
    public decimal Amount
    {
        get => _amount;
        set
        {
            Validations.NumberNotNegativeOrEqualTo0(value);
            _amount = value;
        }
    }

    /// <summary>
    ///     Proizvod na koji se stavka narudžbine odnosi
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
    ///     Id proizvoda na koji se stavka narudžbine odnosi
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
}