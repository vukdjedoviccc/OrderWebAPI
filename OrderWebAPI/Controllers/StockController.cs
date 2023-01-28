using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace OrderWebAPIFaza4.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Stock"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        /// <summary>
        /// Properti interfejsa servisa skladišta koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IStockService _stockService;

        /// <summary>
        /// Konstruktor sa parametrom servisa skaldišta koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="stockService"></param>
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih redova skladišta iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Stock>>> GetAll()
        {
            return await _stockService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za dodavanje novog proizvoda u skladište
        /// </summary>
        /// <param name="request"></param>
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

        /// <summary>
        /// Metoda koja služi za ažuriranje količine proizvoda u skladištu
        /// </summary>
        /// <param name="request"></param>
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
