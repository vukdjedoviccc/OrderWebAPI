using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Order.Repositories
{
    
    public class ProductRepository : IProductRepository 
    {
        
        private readonly DataContext _dataContext;
        
        public ProductRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Add(Product product) 
        {
            var record = new ProductRecord
            {
                Name = product.Name,
                Price = product.Price,
            };

            await _dataContext.Products.AddAsync(record); 
        }

        public async Task Delete(int id) 
        {
            var record = await _dataContext.Products.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (record != null)
            _dataContext.Products.Remove(record);
        }

        public async Task<List<Product>> GetAll()
        {
            var records = await _dataContext.Products.AsNoTracking().ToListAsync();
            List<Product> products = records.Select(x => new Product
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name
            }).ToList(); 
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var record = await _dataContext.Products.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
            Product product = new Product {
                Id = record.Id,
                Price = record.Price,
                Name = record.Name
            };
            return product;
        }
        
        public async Task<List<Product>> ReturnProductsFromDB(List<OrderItem> orderItems)
        {
            var productIds = orderItems.Select(o => o.ProductId).ToList();
            var records = await _dataContext.Products.Include(p => p.PromotionProducts).ThenInclude(pp => pp.Promotion).Where(p => productIds.Contains(p.Id)).AsNoTracking().ToListAsync();
            List<Domain.Model.Product> products = records.Select(x => new Domain.Model.Product
            {
                Id = x.Id,
                Price = x.Price,
                Name = x.Name,
                Discount = x.PromotionProducts.FirstOrDefault(y => y.Promotion.FromDate <= DateTime.Now && DateTime.Now <= y.Promotion.ToDate)?.Promotion?.Discount
            }).ToList();
            return products;
        }

        public async Task Update(Product product)
        {
            var record = new ProductRecord
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
            _dataContext.Products.Update(record);
        }
    }
}
