using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories
{
    
    public class OrderRepository : IOrderRepository
    {
        
        private readonly DataContext _dataContext;

       
        public OrderRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Add(Domain.Model.Order order)
        {
            List<OrderItemRecord> orderItems = order.OrderItems.Select(x => new OrderItemRecord
            {
                Amount = x.Amount,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
            }).ToList();
            var record = new OrderRecord
            {
                CustomerId = order.CustomerId,
                Date = order.Date,
                TotalAmount = order.TotalAmount,
                OrderItems = orderItems
            };
            await _dataContext.Orders.AddAsync(record);
        }

        public async Task Delete(int id)
        {
            var record = await _dataContext.Orders.FirstOrDefaultAsync();
            if (record != null)
            _dataContext.Orders.Remove(record);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Domain.Model.Order>> GetAll()
        {
            var records = await _dataContext.Orders.Include(o => o.OrderItems).ThenInclude(p => p.Product).AsNoTracking().ToListAsync();
            List<Domain.Model.Order> orders = records.Select(CreateOrder).ToList();
            return orders;
        }
       
        private Domain.Model.Order CreateOrder(OrderRecord r)
        {
            Domain.Model.Order order = new Domain.Model.Order
            {
                Id = r.Id,
                CustomerId = r.CustomerId,
                Date = r.Date,
                TotalAmount = r.TotalAmount,
                OrderItems = r.OrderItems.Select(o => new Domain.Model.OrderItem
                {
                    Id = o.Id,
                    Quantity = o.Quantity,
                    Amount = o.Amount,
                    Product = new Domain.Model.Product
                    {
                        Id = o.Product.Id,
                        Name = o.Product.Name,
                        Price = o.Product.Price,
                    },
                    ProductId = o.ProductId,
                    
                }).ToList(),
            };
            return order;
        }

        public async Task<Domain.Model.Order> GetById(int id)
        {
            var record = await _dataContext.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Product).AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
            if (record == null)
            {
                throw new ArgumentNullException($"Objekat sa id {id} se ne nalazi u bazi!");
            }
            Domain.Model.Order order = CreateOrder(record);
            return order;
        }

        public async Task Update(Domain.Model.Order order)
        {
            var orderRecord = await _dataContext.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == order.Id);
            orderRecord.Date = order.Date;
            orderRecord.CustomerId = order.CustomerId;
            orderRecord.TotalAmount = order.TotalAmount;
            List<OrderItemRecord> orderItems = order.OrderItems.Select(x => new OrderItemRecord
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Amount = x.Amount
            }).ToList();
            orderRecord.OrderItems = orderItems;
            _dataContext.Update(orderRecord);
        }

        
    }
}
    
