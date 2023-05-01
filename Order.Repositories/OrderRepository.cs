using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories;

/// <summary>
///     Klasa koja predstavlja repozitorijum narudžbine za pozivanje odgovarajućih metoda koje rade direktno nad bazom
/// </summary>
public class OrderRepository : IOrderRepository
{
    /// <summary>
    ///     Properti datacontext-a zaduženog za rad sa bazom
    /// </summary>
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje
    /// </summary>
    /// <param name="databaseContext"></param>
    public OrderRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChanges()
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Add(Domain.Model.Order order)
    {
        var orderItems = order.OrderItems!.Select(x => new OrderItemRecord
        {
            Amount = x.Amount,
            ProductId = x.ProductId,
            Quantity = x.Quantity
        }).ToList();
        var record = new OrderRecord
        {
            CustomerId = order.CustomerId,
            Date = order.Date,
            TotalAmount = order.TotalAmount,
            OrderItems = orderItems
        };
        await _databaseContext.Orders.AddAsync(record);
    }

    public async Task<List<Domain.Model.Order>> GetAll()
    {
        var records = await _databaseContext.Orders.Include(o => o.OrderItems).ThenInclude(p => p.Product)
            .AsNoTracking()
            .ToListAsync();
        if (records.Count == 0) return null;
        var orders = records.Select(CreateOrder).ToList();
        return orders;
    }

    public async Task<Domain.Model.Order> GetById(int? id)
    {
        var record = await _databaseContext.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Product).AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);
        if (record is null) return null;
        var order = CreateOrder(record);
        return order;
    }

    public async Task Update(Domain.Model.Order order)
    {
        var orderRecord = await _databaseContext.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        orderRecord!.Date = order.Date;
        orderRecord.CustomerId = order.CustomerId;
        orderRecord.TotalAmount = order.TotalAmount;
        var orderItems = order.OrderItems!.Select(x => new OrderItemRecord
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            Amount = x.Amount
        }).ToList();
        orderRecord.OrderItems = orderItems;
        _databaseContext.Update(orderRecord);
    }

    public async Task Delete(int? id)
    {
        var record = await _databaseContext.Orders.FirstOrDefaultAsync();
        if (record != null)
            _databaseContext.Orders.Remove(record);
        await _databaseContext.SaveChangesAsync();
    }

    /// <summary>
    ///     Metoda koja kreira narudžbinu
    /// </summary>
    /// <param name="r"></param>
    private Domain.Model.Order CreateOrder(OrderRecord r)
    {
        var order = new Domain.Model.Order
        {
            Id = r.Id,
            CustomerId = r.CustomerId,
            Date = r.Date,
            TotalAmount = r.TotalAmount,
            OrderItems = r.OrderItems.Select(o => new OrderItem
            {
                Id = o.Id,
                Quantity = o.Quantity,
                Amount = o.Amount,
                Product = new Product
                {
                    Id = o.Product.Id,
                    Name = o.Product.Name,
                    Price = o.Product.Price
                },
                ProductId = o.ProductId
            }).ToList()
        };
        return order;
    }
}