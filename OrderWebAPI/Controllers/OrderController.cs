using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly IOrderService _orderService;

        
        private readonly IStockService _stockService;

        
        public OrderController(IOrderService orderService, IStockService stockService)
        {
            _orderService = orderService;
            _stockService = stockService;
        }

        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Model.Order>>> GetAll()
        {
            return await _orderService.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Order>> GetById(int id)
        {
            return await _orderService.GetById(id);
        }

        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _orderService.Delete(id);
        }

       
        [HttpPost]
        public async Task Post(CreateOrderRequest orderRequest)
        {
            Domain.Model.Order order = new Domain.Model.Order();
            order.CustomerId = orderRequest.CustomerId;
            order.Date = orderRequest.Date;
            var stocks = await _stockService.GetAll();
            foreach (var stock in stocks)
            {
                foreach (var orderItem in orderRequest.Items)
                {
                    if (stock.ProductId == orderItem.ProductId)
                    {
                        List<Model.OrderItem> orderItemsList = orderRequest.Items.Select(x => new Model.OrderItem
                        {
                            Quantity = x.Quantity,
                            ProductId = x.ProductId
                        }).ToList();
                    }
                }


                //order.OrderItems = orderItemsList;
                await _orderService.Add(order);
            }
        }
           
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
