namespace OrderWebAPI.Request;

public class CreatePersonRequest
{
    /// <summary>
    ///     Parametarski konstruktor klase CreatePersonRequest
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    public CreatePersonRequest(string firstName, string lastName, string address, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }


    /// <summary>
    ///     Ime osobe
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Prezime osobe
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Adresa kupca
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    ///     Telefon kupca
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     Email kupca
    /// </summary>
    public string Email { get; set; }
}