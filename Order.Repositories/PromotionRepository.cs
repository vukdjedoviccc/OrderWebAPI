using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repositories
{
    /// <summary>
    /// Klasa koja predstavlja repozitorijum promocije za pozivanje metoda koje rade direktno nad bazom
    /// </summary>
    public class PromotionRepository : IPromotionRepository
    {
        // <summary>
        /// Properti datacontext-a zaduženog za rad sa bazom
        /// </summary>
        private readonly DataContext _dataContext;
        /// <summary>
        /// Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje 
        /// </summary>
        /// <param name="dataContext"></param>
        public PromotionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Add(Promotion promotion) 
        {
            var record = new PromotionRecord
            {
                Name = promotion.Name,
                Discount = promotion.Discount,
                ToDate = promotion.ToDate,
                FromDate = promotion.FromDate,
                PromotionProducts = promotion.Products.Select(p => new PromotionProductRecord
                {
                    ProductId = p.Id,
                }).ToList()
            };
            _dataContext.Promotions.Add(record);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await _dataContext.Promotions.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(record != null)
            _dataContext.Remove(record);
        }

        public async Task<List<Promotion>> GetAll()
        {
            var records = await _dataContext.Promotions.Include(p => p.PromotionProducts).ThenInclude(pp => pp.Product).AsNoTracking().ToListAsync();
            List<Promotion> promotions = records.Select(r => new Promotion
            {
                Id = r.Id,
                Name = r.Name,
                Discount = r.Discount,
                FromDate = r.FromDate,
                ToDate = r.ToDate,
                Products = r.PromotionProducts.Select(p => new Product
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    Price = p.Product.Price
                    
                }).ToList()
            }).ToList();
           return promotions;
        }

        public async Task<Promotion> GetById(int id)
        {
            var record = await _dataContext.Promotions.Include(p => p.PromotionProducts).ThenInclude(pp => pp.Product).Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (record != null)
            {
                Promotion promotion = new Promotion
                {
                    Id = record.Id,
                    Name = record.Name,
                    Discount = record.Discount,
                    FromDate = record.FromDate,
                    ToDate = record.ToDate,
                    Products = record.PromotionProducts.Select(p => GetProduct(p)).ToList()
               };
                return promotion;
            } else 
                return null;
        }
        /// <summary>
        /// Metoda koja vraća proizvod koji ima aktivnu promociju
        /// </summary>
        /// <param name="orderItems"></param>
        private Product GetProduct(PromotionProductRecord promotionProductRecord)
        {
            return new Product
            {
                Id = promotionProductRecord.ProductId,
                Name = promotionProductRecord.Product.Name,
                Price = promotionProductRecord.Product.Price
            };
        }

        public async Task Update(Promotion promotion, List<int> productIds)
        {
            var promotionRecord = new PromotionRecord
            {
                Id = promotion.Id,
                Discount = promotion.Discount,
                FromDate = promotion.FromDate,
                Name = promotion.Name,
                ToDate = promotion.ToDate,
                PromotionProducts = productIds.Select(p => new PromotionProductRecord 
                {
                    ProductId = p
                }).ToList()
            };
            _dataContext.Promotions.Update(promotionRecord);
        }
    }
}
