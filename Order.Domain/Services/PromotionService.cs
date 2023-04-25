using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom promocije kako bi se pristupilo bazi
/// </summary>
public class PromotionService : IPromotionService
{
    // <summary>
    /// Properti repozitorijuma promocije koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IPromotionRepository _promotionRepository;

    /// <summary>
    ///     Konstruktor sa parametrom repozitorijuma promocije koji inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="promotionRepository"></param>
    public PromotionService(IPromotionRepository promotionRepository)
    {
        _promotionRepository = promotionRepository;
    }

    public async Task Add(string name, decimal discount, DateTime fromDate, DateTime toDate, List<int> productIds)
    {
        var products = new List<Product>();

        foreach (var productId in productIds)
        {
            var product = new Product
            {
                Id = productId
            };
            products.Add(product);
        }

        var promotion = new Promotion();
        promotion.Name = name;
        promotion.Discount = discount;
        promotion.FromDate = fromDate;
        promotion.ToDate = toDate;
        promotion.Products = products;
        await _promotionRepository.Add(promotion);
        await _promotionRepository.SaveChanges();
    }

    public async Task DeleteById(int? id)
    {
        await _promotionRepository.Delete(id);
        await _promotionRepository.SaveChanges();
    }

    public async Task<List<Promotion>> GetAll()
    {
        return await _promotionRepository.GetAll();
    }

    public async Task<Promotion> GetById(int id)
    {
        return await _promotionRepository.GetById(id);
    }

    public async Task Update(string name, decimal discount, DateTime fromDate, DateTime toDate, List<int> productIds)
    {
        var promotion = new Promotion();
        promotion.Name = name;
        promotion.Discount = discount;
        promotion.FromDate = fromDate;
        promotion.ToDate = toDate;
        await _promotionRepository.Update(promotion, productIds);
        await _promotionRepository.SaveChanges();
    }
}