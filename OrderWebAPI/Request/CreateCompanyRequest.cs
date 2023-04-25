namespace OrderWebAPI.Request;

public class CreateCompanyRequest
{
    public CreateCompanyRequest(string fullName, string registrationNumber, string adress, string phoneNumber,
        string email)
    {
        FullName = fullName;
        RegistrationNumber = registrationNumber;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    /// <summary>
    ///     Puno ime kompanije
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    ///     Registracioni broj kompanije
    /// </summary>
    public string RegistrationNumber { get; set; }

    /// <summary>
    ///     Adresa kupca
    /// </summary>
    public string Adress { get; set; }

    /// <summary>
    ///     Telefon kupca
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     Email kupca
    /// </summary>
    public string Email { get; set; }
}