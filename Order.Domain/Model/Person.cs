using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na osobe
/// </summary>
public class Person : Customer
{
    private string _firstName;
    private string _lastName;

    /// <summary>
    ///     Bezparametarski konstruktor klase Person
    /// </summary>
    public Person()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase Person
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="id"></param>
    public Person(string firstName, string lastName, string address, string phoneNumber, string email, int id) : base(
        address, phoneNumber, email, id)
    {
        FirstName = firstName;
        LastName = lastName;
    }


    /// <summary>
    ///     Ime osobe
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 15);
            _firstName = value;
        }
    }

    /// <summary>
    ///     Prezime osobe
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 20);
            _lastName = value;
        }
    }
}