namespace OrderWebAPI.Request;

public class CreateCompanyRequest
{
    /// <summary>
    ///     Parametarski konstruktor klase CreateCompanyRequest
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="registrationNumber"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    public CreateCompanyRequest(string fullName, string registrationNumber, string address, string phoneNumber,
        string email)
    {
        FullName = fullName;
        RegistrationNumber = registrationNumber;
        Address = address;
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
    ///     Adresa kompanije
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///     Telefon kompanije
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     Email kompanije
    /// </summary>
    public string Email { get; set; }
}