using Order.Domain.Model;

namespace Order.Domain.Interfaces;

/// <summary>
///     Interfejs koji sadrži sve metode za rad sa bazom kada su objekti promocija u pitanju
/// </summary>
public interface IPromotionRepository
{
    /// <summary>
    ///     Metoda za čuvanje izmena u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja dodaje promociju u bazu
    /// </summary>
    /// <param name="promotion"></param>
    Task Add(Promotion promotion);

    /// <summary>
    ///     Metoda koja briše promociju iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja vraća listu svih promocija iz baze
    /// </summary>
    Task<List<Promotion>> GetAll();

    /// <summary>
    ///     Metoda koja vraća konkretnu promociju iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Promotion> GetById(int id);

    /// <summary>
    ///     Metoda koja ažurira promociju u bazi na osnovu liste id-jeva proizvoda
    /// </summary>
    /// <param name="promotion"></param>
    /// <param name="productIds"></param>
    Task Update(Promotion promotion, List<int> productIds);
}