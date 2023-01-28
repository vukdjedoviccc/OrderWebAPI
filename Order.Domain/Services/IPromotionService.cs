using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    
    public interface IPromotionService
    {
        
        Task<Promotion> GetById(int id);
        
        Task<List<Promotion>> GetAll();
       
        Task Add(Promotion promotion, List<int> productIds);
        
        Task DeleteById(int id);
       
        Task Update(Promotion promotion, List<int> productIds);
    }
}
