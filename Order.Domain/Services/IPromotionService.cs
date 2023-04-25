using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom promocije
/// </summary>
public interface IPromotionService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu promociju na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param
    Task<Promotion> GetById(int id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih promocija
    /// </summary>
    Task<List<Promotion>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala promociju sa njoj odgovarajućim proizvodima
    /// </summary>
    /// <param name="toDate"></param>
    /// <param name="productIds"></param>
    /// <param name="name"></param>
    /// <param name="discount"></param>
    /// <param name="fromDate"></param>
    Task Add(string name, decimal discount, DateTime fromDate, DateTime toDate, List<int> productIds);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu promociju na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task DeleteById(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala promociju sa njoj odgovarajućim
    ///     proizvodima
    /// </summary>
    /// <param name="toDate"></param>
    /// <param name="productIds"></param>
    /// <param name="name"></param>
    /// <param name="discount"></param>
    /// <param name="fromDate"></param>
    Task Update(string name, decimal discount, DateTime fromDate, DateTime toDate, List<int> productIds);
}