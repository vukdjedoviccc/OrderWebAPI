using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom proizvoda
/// </summary>
public interface IProductService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala proizvod
    /// </summary>
    /// <param name="product"></param>
    Task AddProduct(string name, decimal price);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretan proizvod na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param
    Task<Product> GetById(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih proizvoda
    /// </summary>
    Task<List<Product>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretan proizvod na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala proizvod
    /// </summary>
    /// <param name="product"></param>
    Task Update(int? id, string name, decimal price);
}