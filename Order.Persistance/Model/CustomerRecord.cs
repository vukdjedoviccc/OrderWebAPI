namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "Customer" u bazu
/// </summary>
public class CustomerRecord
{
    // <summary>
    /// Id kupca
    /// </summary>
    public int? Id { get; set; }

    // <summary>
    /// Adresa kupca
    /// </summary>
    public string Adress { get; set; }

    // <summary>
    /// Broj telefona kupca
    /// </summary>
    public string PhoneNumber { get; set; }

    // <summary>
    /// Email kupca
    /// </summary>
    public string Email { get; set; }

    // <summary>
    /// Navigacioni properti ka narudžbini
    /// </summary>
    public List<OrderRecord> Orders { get; set; }
}