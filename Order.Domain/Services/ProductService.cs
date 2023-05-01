using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom proizvoda kako bi se pristupilo bazi
/// </summary>
public class ProductService : IProductService
{
    /// <summary>
    ///     Properti repozitorijuma proizvoda koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IProductRepository _productRepository;

    /// <summary>
    ///     Konstruktor sa parametrom repozitorijuma proizvoda koji inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="productRepository"></param>
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddProduct(string name, decimal price)
    {
        await _productRepository.Add(name, price);
        await _productRepository.SaveChanges();
    }

    public async Task Delete(int? id)
    {
        await _productRepository.Delete(id);
        await _productRepository.SaveChanges();
    }

    public async Task<List<Product>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<Product> GetById(int? id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task Update(int? id, string name, decimal price)
    {
        await _productRepository.Update(id, name, price);
        await _productRepository.SaveChanges();
    }
}