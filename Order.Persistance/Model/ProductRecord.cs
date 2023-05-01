namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "Product" u bazu
/// </summary>
public class ProductRecord
{
    /// <summary>
    ///     Id proizvoda
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Ime proizvoda
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Cena proizvoda
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Navigacioni properti ka listi stavki narudžbine
    /// </summary>
    public List<OrderItemRecord> OrderItems { get; set; }

    /// <summary>
    ///     Navigacioni properti ka listi promocija sa njoj odgovarajućim proizvodima
    /// </summary>
    public List<PromotionProductRecord> PromotionProducts { get; set; }

    /// <summary>
    ///     Navigacioni properti ka skladištu
    /// </summary>
    public StockRecord Stock { get; set; }
}