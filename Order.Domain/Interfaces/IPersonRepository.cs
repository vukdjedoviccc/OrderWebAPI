using Order.Domain.Model;

namespace Order.Domain.Interfaces;

/// <summary>
///     Interfejs koji sadrži sve metode za rad sa bazom kada su objekti osobe u pitanju
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    ///     Metoda koja čuva izmene u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja dodaje osobu u bazu
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    Task Add(string firstName, string lastName, string email, string address, string phoneNumber);

    /// <summary>
    ///     Metoda koja briše osobu iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja vraća listu svih osoba iz baze
    /// </summary>
    Task<List<Person>> GetAll();

    /// <summary>
    ///     Metoda koja vraća konkretnu osobu iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Person> GetById(int? id);

    /// <summary>
    ///     Metoda koja ažurira osobu u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    Task Update(int? id, string firstName, string lastName, string email, string address, string phoneNumber);
}