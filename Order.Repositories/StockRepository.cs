using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories;

/// <summary>
///     Klasa koja predstavlja repozitorijum skladišta za pozivanje metoda koje rade direktno nad bazom
/// </summary>
public class StockRepository : IStockRepository
{
    // <summary>
    /// Properti datacontext-a zaduženog za rad sa bazom
    /// </summary>
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje
    /// </summary>
    /// <param name="databaseContext"></param>
    public StockRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChanges()
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Stock> GetById(int id)
    {
        var record = await _databaseContext.Stocks.Where(s => s.ProductId == id).AsNoTracking().FirstOrDefaultAsync();
        if (record is null) return null;
        var stock = new Stock
        {
            Quantity = record.Quantity,
            ProductId = record.ProductId,
            Id = record.Id
        };
        return stock;
    }

    public async Task Update(int id, int productId, int quantity)
    {
        var record = new StockRecord
        {
            Id = id,
            ProductId = productId,
            Quantity = quantity
        };
        _databaseContext.Stocks.Update(record);
    }

    public async Task Add(int productId, int quantity)
    {
        var record = new StockRecord
        {
            ProductId = productId,
            Quantity = quantity
        };

        await _databaseContext.Stocks.AddAsync(record);
    }

    public async Task<List<Stock>> GetAll()
    {
        var records = await _databaseContext.Stocks.AsNoTracking().ToListAsync();
        if (records.Count == 0) return null;
        var stocks = records.Select(x => new Stock
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Quantity = x.Quantity
        }).ToList();
        return stocks;
    }
}