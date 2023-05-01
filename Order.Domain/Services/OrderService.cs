using Order.Domain.Helper;
using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom narudžbine kako bi se pristupilo bazi
/// </summary>
public class OrderService : IOrderService
{
    /// <summary>
    ///     Properti interfejsa repozitorijuma narudžbine koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IOrderRepository _orderRepository;

    /// <summary>
    ///     Properti repozitorijuma proizvoda koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IProductRepository _productRepository;

    /// <summary>
    ///     Konstruktor sa parametrima repozitorijuma narudžbine i proizvoda koje inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="orderRepository"></param>
    /// <param name="productRepository"></param>
    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task Delete(int? id)
    {
        await _orderRepository.Delete(id);
    }

    public async Task<List<Model.Order>> GetAll()
    {
        var orders = await _orderRepository.GetAll();
        JsonHelper.WriteOrdersToJSONFile(orders);
        return orders;
    }

    public async Task Add(int? customerId, DateTime? date, List<OrderItem>? items)
    {
        var order1 = await SetOrder(customerId, date, items);
        await _orderRepository.Add(order1);
        await _orderRepository.SaveChanges();
    }

    public async Task Update(int? customerId, DateTime? date, List<OrderItem>? items)
    {
        var order1 = await SetOrder(customerId, date, items);
        await _orderRepository.Update(order1);
        await _orderRepository.SaveChanges();
    }

    public async Task<Model.Order> GetById(int? id)
    {
        return await _orderRepository.GetById(id);
    }

    /// <summary>
    ///     Metoda koja postavlja vrednosti narudžbine
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="date"></param>
    /// <param name="items"></param>
    private async Task<Model.Order> SetOrder(int? customerId, DateTime? date, List<OrderItem>? items)
    {
        var productsFromDb = await _productRepository.ReturnProductsFromDb(items);
        foreach (var item in items)
            item.Product = productsFromDb.FirstOrDefault(p => p.Id == item.ProductId)!;
        var order = new Model.Order();
        order.CustomerId = customerId;
        order.Date = date;
        order.OrderItems = items;
        order.CalculateTotalAmount();
        return order;
    }
}