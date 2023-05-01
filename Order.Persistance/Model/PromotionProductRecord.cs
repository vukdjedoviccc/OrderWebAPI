namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "PromotionProduct" u bazu
/// </summary>
public class PromotionProductRecord
{
    /// <summary>
    ///     Navigacioni properti ka proizvodu
    /// </summary>
    public ProductRecord Product { get; set; }

    /// <summary>
    ///     Navigacioni properti ka promociji
    /// </summary>
    public PromotionRecord Promotion { get; set; }

    /// <summary>
    ///     Id proizvoda
    /// </summary>
    public int? ProductId { get; set; }

    /// <summary>
    ///     Id promocije
    /// </summary>
    public int PromotionId { get; set; }
}