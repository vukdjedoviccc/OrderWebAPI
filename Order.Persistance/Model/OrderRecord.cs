namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "Order" u bazu
/// </summary>
public class OrderRecord
{
    // <summary>
    /// Id narudžbine
    /// </summary>
    public int Id { get; set; }

    // <summary>
    /// Id kupca
    /// </summary>
    public int? CustomerId { get; set; }

    // <summary>
    /// Vreme narudžbine
    /// </summary>
    public DateTime? Date { get; set; }

    // <summary>
    /// Ukupan iznos narudžbine
    /// </summary>
    public decimal TotalAmount { get; set; }

    // <summary>
    /// Navigacioni properti ka listi stavki narudžbine
    /// </summary>
    public List<OrderItemRecord> OrderItems { get; set; }

    // <summary>
    /// Navigacioni properti ka kupcu
    /// </summary>
    public CustomerRecord Customer { get; set; }
}