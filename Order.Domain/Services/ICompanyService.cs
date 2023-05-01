using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom kompanije
/// </summary>
public interface ICompanyService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala kompaniju
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="registrationNumber"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    Task Add(string fullName, string registrationNumber, string address, string phoneNumber, string email);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu kompaniju na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Company> GetById(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih kompanija
    /// </summary>
    Task<List<Company>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu kompaniju na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala kompaniju
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fullName"></param>
    /// <param name="registrationNumber"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
    Task Update(int? id, string address, string fullName, string email, string phoneNumber, string registrationNumber);
}