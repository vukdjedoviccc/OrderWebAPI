using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na kompanije
/// </summary>
public class Company : Customer
{
    private string _fullName;
    private string _registrationNumber;

    /// <summary>
    ///     Bezparametarski konstruktor klase Company
    /// </summary>
    public Company()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase Customer
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="registrationNumber"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    /// <param name="id"></param>
    public Company(string fullName, string registrationNumber, string address, string phoneNumber, string email, int id)
        : base(address, phoneNumber, email, id)
    {
        FullName = fullName;
        RegistrationNumber = registrationNumber;
    }

    /// <summary>
    ///     Puno ime kompanije
    /// </summary>
    public string FullName
    {
        get => _fullName;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 50);
            _fullName = value;
        }
    }

    /// <summary>
    ///     Registracioni broj kompanije
    /// </summary>
    public string RegistrationNumber
    {
        get => _registrationNumber;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthEqualTo(value, 8);
            _registrationNumber = value;
        }
    }
}