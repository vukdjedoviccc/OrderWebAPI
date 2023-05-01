using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na kupce
/// </summary>
public class Customer
{
    private string _address;
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
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="id"></param>
    public Customer(string address, string phoneNumber, string email, int id)
    {
        Address = address;
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
    public string Address
    {
        get => _address;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 40);
            _address = value;
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