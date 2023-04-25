namespace Order.Domain.Interfaces;

/// <summary>
///     Interfejs koji sadrži sve metode za rad sa bazom kada su objekti narudžbine u pitanju
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    ///     Metoda koja čuva izmene u bazi
    /// </summary>
    Task SaveChanges();

    /// <summary>
    ///     Metoda koja dodaje narudžbinu u bazu
    /// </summary>
    /// <param name="order"></param>
    Task Add(Model.Order order);

    /// <summary>
    ///     Metoda koja briše narudžbinu iz baze na osnovu id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja vraća narudžbinu iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="order"></param>
    Task<Model.Order> GetById(int? id);

    /// <summary>
    ///     Metoda koja vraća listu svih narudžbina iz baze
    /// </summary>
    /// <param name="order"></param>
    Task<List<Model.Order>> GetAll();

    /// <summary>
    ///     Metoda koja ažurira narudžbinu u bazi
    /// </summary>
    /// <param name="order"></param>
    Task Update(Model.Order order);
}