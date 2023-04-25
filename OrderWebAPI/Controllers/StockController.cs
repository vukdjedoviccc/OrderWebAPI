using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Stock"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa proizvoda koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IProductService _productService;

    /// <summary>
    ///     Properti interfejsa servisa skladišta koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IStockService _stockService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa skaldišta koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="stockService"></param>
    /// <param name="productService"></param>
    public StockController(IStockService stockService, IProductService productService)
    {
        _stockService = stockService;
        _productService = productService;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih redova skladišta iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Stock>>> GetAll()
    {
        var stocks = await _stockService.GetAll();
        if (stocks is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat skladišta!");
        return stocks;
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje novog proizvoda u skladište
    /// </summary>
    /// <param name="request"></param>
    [HttpPost("AddProductToStock")]
    public async Task Post(CreateStockRequest request)
    {
        if (request.ProductId <= 0)
            throw new ArgumentException("ProductId ne može biti nula ili negativan broj!");
        var product = await _productService.GetById(request.ProductId);
        if (product is null)
            throw new ArgumentException($"Proizvod sa Id-jem {request.ProductId} se ne nalazi u bazi!");
        if (request.Quantity <= 0)
            throw new ArgumentException("Quantity ne može biti nula ili negativan broj!");
        var stockFromDatabase = await _stockService.GetById(request.ProductId);
        var stock = new Stock();
        if (stockFromDatabase == null)
        {
            stock.ProductId = request.ProductId;
            stock.Quantity = request.Quantity;
            await _stockService.Add(stock.ProductId, stock.Quantity);
        }
        else
        {
            throw new Exception($"Proizvod sa id-jem {request.ProductId} se već nalazi na skladištu!");
        }
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje količine proizvoda u skladištu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    [HttpPut("UpdateProductQuantity")]
    public async Task Put(int id, CreateStockRequest request)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (request.ProductId <= 0)
            throw new ArgumentException("ProductId ne može biti nula ili negativan broj!");
        var product = await _productService.GetById(request.ProductId);
        if (product is null)
            throw new NullReferenceException($"Proizvod sa Id-jem {request.ProductId} se ne nalazi u bazi!");
        if (request.Quantity <= 0)
            throw new ArgumentException("Quantity ne može biti nula ili negativan broj!");

        var stockFromDatabase = await _stockService.GetById(request.ProductId);
        if (stockFromDatabase != null)
        {
            stockFromDatabase.Quantity = request.Quantity;
            stockFromDatabase.ProductId = request.ProductId;
            await _stockService.Update(id, stockFromDatabase.ProductId, stockFromDatabase.Quantity);
        }
        else
        {
            throw new Exception($"Proizvod sa id-jem {request.ProductId} se ne nalazi na skladištu!");
        }
    }
}