using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Product"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa proizvoda koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IProductService _productService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa proizvoda koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="productService"></param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje proizvoda u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestProduct"></param>
    [HttpPut("{id}")]
    public async Task Put(int? id, CreateProductRequest requestProduct)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (string.IsNullOrEmpty(requestProduct.Name))
            throw new ArgumentException("Name ne može biti null ili prazan string!");
        if (requestProduct.Price <= 0)
            throw new ArgumentException("Price ne može biti nula ili negativan broj!");
        var product = await _productService.GetById(id);
        if (product == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        product.Name = requestProduct.Name;
        product.Price = requestProduct.Price;
        await _productService.Update(id, requestProduct.Name, requestProduct.Price);
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih proizvoda iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Product>?>> GetAll()
    {
        var products = await _productService.GetAll();
        if (products is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat proizvoda!");
        return products;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje konkretnog proizvoda iz baze na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        var product = await _productService.GetById(id);
        if (product == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        return product;
    }

    /// <summary>
    ///     Metoda koja služi za brisanje konkretnog proizvoda iz baze na osnovu njegovog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task Delete(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        await _productService.Delete(id);
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje novog proizvoda u bazu
    /// </summary>
    /// <param name="requestProduct"></param>
    [HttpPost]
    public async Task Post(CreateProductRequest requestProduct)
    {
        if (string.IsNullOrEmpty(requestProduct.Name))
            throw new ArgumentException("Name ne može biti null ili prazan string!");
        if (requestProduct.Price <= 0)
            throw new ArgumentException("Price ne može biti nula ili negativan broj!");
        var product = new Product();
        product.Price = requestProduct.Price;
        product.Name = requestProduct.Name;

        await _productService.AddProduct(product.Name, product.Price);
    }
}