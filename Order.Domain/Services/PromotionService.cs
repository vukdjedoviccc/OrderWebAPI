using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    
    public class PromotionService : IPromotionService
    {
        
        private readonly IPromotionRepository _promotionRepository;
        
        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task Add(Promotion promotion, List<int> productIds)
        {
            List<Product> products = new List<Product>();
            
            foreach (int productId in productIds)
            {
                var product = new Product
                {
                    Id = productId,
                };
                products.Add(product);
            }
           promotion.Products = products;
           await _promotionRepository.Add(promotion);
           await _promotionRepository.SaveChanges();
        }

        public async Task DeleteById(int id)
        {
            await _promotionRepository.Delete(id);
            await _promotionRepository.SaveChanges();
        }

        public async Task<List<Promotion>> GetAll()
        {
            return await _promotionRepository.GetAll();
        }

        public async Task<Promotion> GetById(int id)
        {
            return await _promotionRepository.GetById(id); 
        }

        public async Task Update(Promotion promotion, List<int> productIds)
        {
            await _promotionRepository.Update(promotion, productIds);
            await _promotionRepository.SaveChanges();
        }
    }
}
