using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom narudžbine
/// </summary>
public interface IOrderService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih narudžbina
    /// </summary>
    Task<List<Model.Order>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu narudžbinu na osnovu njenog id-ja
    /// </summary>
    Task<Model.Order> GetById(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu narudžbinu na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    Task Delete(int? id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala narudžbinu
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="date"></param>
    /// <param name="items"></param>
    /// <param name="order"></param>
    Task Add(int? customerId, DateTime? date, List<OrderItem>? items);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala narudžbinu
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="date"></param>
    /// <param name="items"></param>
    /// <param name="order"></param>
    Task Update(int? customerId, DateTime? date, List<OrderItem>? items);
}