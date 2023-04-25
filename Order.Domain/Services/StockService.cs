using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom skladišta kako bi se pristupilo bazi
/// </summary>
public class StockService : IStockService
{
    // <summary>
    /// Properti repozitorijuma skladišta koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IStockRepository _stockRepository;

    /// <summary>
    ///     Konstruktor sa parametrom repozitorijuma skladišta koji inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="stockRepository"></param>
    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<Stock> GetById(int id)
    {
        return await _stockRepository.GetById(id);
    }

    public async Task Update(int id, int productId, int quantity)
    {
        await _stockRepository.Update(id, productId, quantity);
        await _stockRepository.SaveChanges();
    }

    public async Task Add(int productId, int quantity)
    {
        await _stockRepository.Add(productId, quantity);
        await _stockRepository.SaveChanges();
    }

    public async Task<List<Stock>> GetAll()
    {
        return await _stockRepository.GetAll();
    }
}