using Order.Domain.Model;

namespace Order.Domain.Interfaces;

/// <summary>
///     Interfejs koji sadrži sve metode za rad sa bazom kada su objekti kompanija u pitanju
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    ///     Metoda koja čuva izmene u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja dodaje kompaniju u bazu
    /// </summary>
    /// <param name="company"></param>
    Task Add(string fullName, string registrationNumber, string adress, string phoneNumber, string Email);

    /// <summary>
    ///     Metoda koja briše konkretnu kompaniju iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja vraća listu svih kompanija iz baze
    /// </summary>
    Task<List<Company>> GetAll();

    /// <summary>
    ///     Metoda koja vraća konkretnu kompaniju iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Company> GetById(int? id);

    /// <summary>
    ///     Metoda koja ažurira kompaniju u bazi
    /// </summary>
    /// <param name="company"></param>
    Task Update(int? id, string address, string fullName, string email, string phoneNumber, string registrationNumbery);
}