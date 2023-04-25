using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na kupce
/// </summary>
public class Customer
{
    private string _adress;
    private string _email;
    private int _id;
    private string _phoneNumber;

    /// <summary>
    ///     Bezparametarski konstruktor klase Customer
    /// </summary>
    public Customer()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase Customer
    /// </summary>
    /// <param name="adress"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="id"></param>
    public Customer(string adress, string phoneNumber, string email, int id)
    {
        Adress = adress;
        PhoneNumber = phoneNumber;
        Email = email;
        Id = id;
    }

    /// <summary>
    ///     Id kupca
    /// </summary>
    public int? Id
    {
        get => _id;
        set
        {
            Validations.NotNull(value);
            Validations.NumberNotNegativeOrEqualTo0(value);
            _id = (int)value;
        }
    }

    /// <summary>
    ///     Adresa kupca
    /// </summary>
    public string Adress
    {
        get => _adress;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 40);
            _adress = value;
        }
    }

    /// <summary>
    ///     Telefon kupca
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 10);
            _phoneNumber = value;
        }
    }

    /// <summary>
    ///     Email kupca
    /// </summary>
    public string Email
    {
        get => _email;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 30);
            _email = value;
        }
    }
}