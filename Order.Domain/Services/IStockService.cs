using Order.Domain.Model;

namespace Order.Domain.Services;

public interface IStockService
{
    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala red u skladištu(količinu proizvoda)
    /// </summary>
    /// ///
    /// <param name="id"></param>
    /// <param name="quantity"></param>
    /// <param name="productId"></param>
    Task Update(int id, int productId, int quantity);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila red iz skladišta na osnovu id-ja
    /// </summary>
    /// <param name="id"></param>
    Task<Stock> GetById(int id);

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila sve redove iz skladišta
    /// </summary>
    Task<List<Stock>> GetAll();

    /// <summary>
    ///     Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala red iz skladišta(dodala novi proizvod u
    ///     skladište)
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    Task Add(int productId, int quantity);
}