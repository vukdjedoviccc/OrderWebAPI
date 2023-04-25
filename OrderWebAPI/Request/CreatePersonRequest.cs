namespace OrderWebAPI.Request;

public class CreatePersonRequest
{
    public CreatePersonRequest(string firstName, string lastName, string adress, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public CreatePersonRequest()
    {
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