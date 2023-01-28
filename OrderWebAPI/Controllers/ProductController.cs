using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
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

        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productService.GetAll();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        
        [HttpDelete("{id}")]
        public async Task Delete(int id) 
        {
            await _productService.Delete(id);
        }

       
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
