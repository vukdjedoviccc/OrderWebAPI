using Order.Domain.Model;

namespace Order.Domain.Interfaces;

/// <summary>
///     Interfejs koji sadrži sve metode za rad sa bazom kada su objekti proizvoda u pitanju
/// </summary>
public interface IProductRepository
{
    /// <summary>
    ///     Metoda za čuvanje izmena u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja dodaje proizvod u bazu
    /// </summary>
    /// <param name="product"></param>
    Task Add(string name, decimal price);

    /// <summary>
    ///     Metoda koja briše proizvod iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja vraća listu svih proizvoda iz baze
    /// </summary>
    Task<List<Product>> GetAll();

    /// <summary>
    ///     Metoda koja vraća konkretan proizvod iz baze na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Product> GetById(int? id);

    /// <summary>
    ///     Metoda koja vraća listu proizvoda iz baze koji čine stavke narudžbine
    /// </summary>
    /// <param name="orderItems"></param>
    Task<List<Product>> ReturnProductsFromDB(List<OrderItem> orderItems);

    /// <summary>
    ///     Metoda koja ažurira proizvod u bazi
    /// </summary>
    /// <param name="product"></param>
    Task Update(int? id, string name, decimal price);
}