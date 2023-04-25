using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories;

/// <summary>
///     Klasa koja predstavlja repozitorijum proizvoda za pozivanje metoda koje rade direktno nad bazom
/// </summary>
public class ProductRepository : IProductRepository
{
    // <summary>
    /// Properti datacontext-a zaduženog za rad sa bazom
    /// </summary>
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje
    /// </summary>
    /// <param name="databaseContext"></param>
    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChanges()
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Add(string name, decimal price)
    {
        var record = new ProductRecord
        {
            Name = name,
            Price = price
        };

        await _databaseContext.Products.AddAsync(record);
    }

    public async Task Delete(int? id)
    {
        var record = await _databaseContext.Products.Where(r => r.Id == id).FirstOrDefaultAsync();
        if (record != null)
            _databaseContext.Products.Remove(record);
    }

    public async Task<List<Product>> GetAll()
    {
        var records = await _databaseContext.Products.AsNoTracking().ToListAsync();
        if (records.Count == 0) return null;
        var products = records.Select(x => new Product
        {
            Id = x.Id,
            Price = x.Price,
            Name = x.Name
        }).ToList();
        return products;
    }

    public async Task<Product> GetById(int? id)
    {
        var record = await _databaseContext.Products.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (record is null) return null;
        var product = new Product
        {
            Id = record.Id,
            Price = record.Price,
            Name = record.Name
        };
        return product;
    }

    public async Task<List<Product>> ReturnProductsFromDB(List<OrderItem> orderItems)
    {
        var productIds = orderItems.Select(o => o.ProductId).ToList();
        var records = await _databaseContext.Products.Include(p => p.PromotionProducts).ThenInclude(pp => pp.Promotion)
            .Where(p => productIds.Contains((int)p.Id)).AsNoTracking().ToListAsync();
        var products = records.Select(x => new Product
        {
            Id = x.Id,
            Price = x.Price,
            Name = x.Name,
            Discount = x.PromotionProducts
                .FirstOrDefault(y => y.Promotion.FromDate <= DateTime.Now && DateTime.Now <= y.Promotion.ToDate)
                ?.Promotion?.Discount
        }).ToList();
        return products;
    }

    public async Task Update(int? id, string name, decimal price)
    {
        var record = new ProductRecord
        {
            Id = id,
            Name = name,
            Price = price
        };
        _databaseContext.Products.Update(record);
    }
}