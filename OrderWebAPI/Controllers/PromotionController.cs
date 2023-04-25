using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Promotion"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PromotionController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa promocije koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IPromotionService _promotionService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa promocije koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="promotionService"></param>
    public PromotionController(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje promocije u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="promotionRequest"></param>
    [HttpPut("{id}")]
    public async Task Put(int id, CreatePromotionRequest promotionRequest)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (string.IsNullOrEmpty(promotionRequest.Name))
            throw new ArgumentException("Name ne može biti null ili prazan string!");
        if (promotionRequest.Discount <= 0)
            throw new ArgumentException("Discount ne može biti negativan broj ili jednak nuli!");
        var promotion = await _promotionService.GetById(id);
        if (promotion == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        promotion.FromDate = promotionRequest.FromDate;
        promotion.ToDate = promotionRequest.ToDate;
        promotion.Discount = promotionRequest.Discount;
        promotion.Name = promotionRequest.Name;
        var productIds = new List<int>();
        foreach (var productId in promotionRequest.ProductIds)
            productIds.Add(productId);
        await _promotionService.Update(promotion.Name, promotion.Discount, promotion.ToDate, promotion.FromDate,
            productIds);
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih promocija iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Promotion>>> GetAll()
    {
        var promotions = await _promotionService.GetAll();
        if (promotions is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat promocije!");
        return promotions;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje konkretne promocije iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Promotion>> GetById(int id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        var promotion = await _promotionService.GetById(id);
        if (promotion == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        return promotion;
    }

    /// <summary>
    ///     Metoda koja služi za brisanje konkretne promocije iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task DeleteById(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        await _promotionService.DeleteById(id);
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje nove promocije u bazu
    /// </summary>
    /// <param name="promotionRequest"></param>
    [HttpPost]
    public async Task Post(CreatePromotionRequest promotionRequest)
    {
        if (string.IsNullOrEmpty(promotionRequest.Name))
            throw new ArgumentException("Name ne može biti null ili prazan string!");
        if (promotionRequest.Discount <= 0)
            throw new ArgumentException("Discount ne može biti negativan broj ili jednak nuli!");
        var promotion = new Promotion();
        promotion.Name = promotionRequest.Name;
        promotion.FromDate = promotionRequest.FromDate;
        promotion.ToDate = promotionRequest.ToDate;
        promotion.Discount = promotionRequest.Discount;
        await _promotionService.Add(promotion.Name, promotion.Discount, promotion.FromDate, promotion.ToDate,
            promotionRequest.ProductIds);
    }
}