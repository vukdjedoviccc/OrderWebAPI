namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "Stock" u bazu
/// </summary>
public class StockRecord
{
    /// <summary>
    ///     Id reda skladišta proizvoda u skladištu
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    ///     Količina proizvoda u skladištu
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    ///     Navigacioni properti ka listi proizvoda
    /// </summary>
    public ProductRecord Product { get; set; }

    /// <summary>
    ///     Id proizvoda u skladištu
    /// </summary>
    public int ProductId { get; set; }
}