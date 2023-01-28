using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Order"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Properti interfejsa servisa narudžbine koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Properti interfejsa servisa skladišta koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IStockService _stockService;

        /// <summary>
        /// Konstruktor sa parametrom servisa narudžbine koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(IOrderService orderService, IStockService stockService)
        {
            _orderService = orderService;
            _stockService = stockService;
        }

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih narudžbina iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Model.Order>>> GetAll()
        {
            return await _orderService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za vraćanje konkretne narudžbine iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Order>> GetById(int id)
        {
            return await _orderService.GetById(id);
        }

        /// <summary>
        /// Metoda koja služi za brisanje konkretne narudžbine iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderService.Delete(id);
        }

        /// <summary>
        /// Metoda koja služi za dodavanje nove narudžbine u bazu
        /// </summary>
        /// <param name="orderRequest"></param>
        [HttpPost]
        public async Task Post(CreateOrderRequest orderRequest)
        {
            Domain.Model.Order order = new Domain.Model.Order();
            order.CustomerId = orderRequest.CustomerId;
            order.Date = orderRequest.Date;
            List<Model.OrderItem> orderItemsList = orderRequest.Items.Select(x => new Model.OrderItem
            {
                Quantity = x.Quantity,
                ProductId = x.ProductId
            }).ToList();
            order.OrderItems = orderItemsList;
            await _orderService.Add(order);
        }
        /// <summary>
        /// Metoda koja služi za ažuriranje narudžbine u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderRequest"></param>
        [HttpPut]
        public async Task Put(int id, CreateOrderRequest orderRequest)
        {
            var order = await _orderService.GetById(id);
            if (order != null)
            {
                order.Date = orderRequest.Date;
                order.CustomerId = orderRequest.CustomerId;
                order.OrderItems = orderRequest.Items.Select(or => new Model.OrderItem
                {
                    ProductId = or.ProductId,
                    Quantity = or.Quantity,
                }).ToList();
                await _orderService.Update(order);
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }

        }
    }
} 
