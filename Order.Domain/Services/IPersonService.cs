using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom osobe
/// </summary>
public interface IPersonService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala osobu
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    Task Add(string firstName, string lastName, string email, string address, string phoneNumber);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu osobu na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Person> GetById(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih osoba
    /// </summary>
    Task<List<Person>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu osobu na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala osobu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    Task Update(int? id, string firstName, string lastName, string email, string address, string phoneNumber);
}