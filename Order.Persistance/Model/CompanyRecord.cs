namespace Order.Persistance.Model;

/// <summary>
///     Klasa koja sadrži postavku za mapiranje tabele "Company" u bazu
/// </summary>
public class CompanyRecord : CustomerRecord
{
    /// <summary>
    ///     Puno ime kompanije
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    ///     Registracioni broj kompanije
    /// </summary>
    public string RegistrationNumber { get; set; }
}