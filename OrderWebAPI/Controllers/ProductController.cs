using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Product"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Properti interfejsa servisa proizvoda koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IProductService _productService;
        /// <summary>
        /// Konstruktor sa parametrom servisa proizvoda koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Metoda koja služi za ažuriranje proizvoda u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestProduct"></param>
        [HttpPut("{id}")]
        public async Task Put(int id, CreateProductRequest requestProduct)
        {
            var product = await _productService.GetById(id);
            if (product != null)
            { 
                product.Name = requestProduct.Name;
                product.Price = requestProduct.Price;
                await _productService.Update(product);
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }
            
        }

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih proizvoda iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za vraćanje konkretnog proizvoda iz baze na osnovu njegovog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        /// <summary>
        /// Metoda koja služi za brisanje konkretnog proizvoda iz baze na osnovu njegovog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id) 
        {
            await _productService.Delete(id);
        }

        /// <summary>
        /// Metoda koja služi za dodavanje novog proizvoda u bazu
        /// </summary>
        /// <param name="requestProduct"></param>
        [HttpPost] 
        public async Task Post(CreateProductRequest requestProduct)
        {
            Product product = new Product();
            product.Price = requestProduct.Price;
            product.Name = requestProduct.Name;

            await _productService.AddProduct(product);
        }
    }
}
