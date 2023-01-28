using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace OrderWebAPIFaza4.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
       
        private readonly IStockService _stockService;

        
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Stock>>> GetAll()
        {
            return await _stockService.GetAll();
        }

        
        [HttpPost("AddProductToStock")]
        public async Task Post(CreateStockRequest request)
        {
            var stockFromDatabase = await _stockService.GetById(request.ProductId);
            if (stockFromDatabase != null)
            {
                throw new Exception($"Proizvod sa id-jem {request.ProductId} se već nalazi na skladištu!");
            }
            else
            {
                Stock stock = new();
                stock.ProductId = request.ProductId;
                stock.Quantity = request.Quantity;
                await _stockService.Add(stock);
            }
        }

        
        [HttpPut("UpdateProductQuantity")]
        public async Task Put(CreateStockRequest request)
        {
            var stockFromDatabase = await _stockService.GetById(request.ProductId);
            if (stockFromDatabase != null)
            {
                stockFromDatabase.Quantity += request.Quantity;
                stockFromDatabase.ProductId = request.ProductId; 
                await _stockService.Update(stockFromDatabase);
            }
            else
            {
                throw new Exception($"Proizvod sa id-jem {request.ProductId} se ne nalazi na skladištu!");
            }
        }
    }
}
