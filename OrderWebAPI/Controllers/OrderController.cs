using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Order"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa narudžbine koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IOrderService _orderService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa narudžbine koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="orderService"></param>
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih narudžbina iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Order.Domain.Model.Order>>> GetAll()
    {
        var orders = await _orderService.GetAll();
        if (orders is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat narudžbine!");
        return orders;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje konkretne narudžbine iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Order.Domain.Model.Order>> GetById(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        var order = await _orderService.GetById(id);
        if (order == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        return order;
    }

    /// <summary>
    ///     Metoda koja služi za brisanje konkretne narudžbine iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task Delete(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        await _orderService.Delete(id);
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje nove narudžbine u bazu
    /// </summary>
    /// <param name="orderRequest"></param>
    [HttpPost]
    public async Task Post(CreateOrderRequest orderRequest)
    {
        if (orderRequest.CustomerId <= 0)
            throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (orderRequest.Items == null)
            throw new ArgumentException("Items ne može biti null!");
        var order = new Order.Domain.Model.Order();
        order.CustomerId = orderRequest.CustomerId;
        order.Date = orderRequest.Date;
        var orderItemsList = orderRequest.Items.Select(x => new OrderItem
        {
            Quantity = x.Quantity,
            ProductId = x.ProductId
        }).ToList();
        order.OrderItems = orderItemsList;
        await _orderService.Add(order.CustomerId, order.Date, order.OrderItems);
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje narudžbine u bazi
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderRequest"></param>
    [HttpPut]
    public async Task Put(int orderId, CreateOrderRequest orderRequest)
    {
        if (orderId <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (orderRequest.CustomerId <= 0)
            throw new ArgumentException("CustomerId ne može biti negativan broj ili jednak nuli!");
        if (orderRequest.Items == null)
            throw new ArgumentException("Items ne može biti null!");
        var order = await _orderService.GetById(orderId);
        if (order == null) throw new NullReferenceException($"Objekat sa Id-jem {orderId} se ne nalazi u bazi!");

        order.Date = orderRequest.Date;
        order.CustomerId = orderRequest.CustomerId;
        order.OrderItems = orderRequest.Items.Select(or => new OrderItem
        {
            ProductId = or.ProductId,
            Quantity = or.Quantity
        }).ToList();
        await _orderService.Update(order.CustomerId, order.Date, order.OrderItems);
    }
}