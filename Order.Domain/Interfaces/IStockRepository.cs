using Order.Domain.Model;

namespace Order.Domain.Interfaces;

public interface IStockRepository
{
    /// <summary>
    ///     Metoda za čuvanje izmena u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja vraća konkretan red skladišta iz baze na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Stock> GetById(int id);

    /// <summary>
    ///     Metoda koja vraća listu svih redova skladišta iz baze
    /// </summary>
    Task<List<Stock>> GetAll();

    /// <summary>
    ///     Metoda koja ažurira red skladišta u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="quantity"></param>
    /// <param name="productId"></param>
    Task Update(int id, int productId, int quantity);

    /// <summary>
    ///     Metoda koja dodaje red skladišta u bazu
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    Task Add(int productId, int quantity);
}