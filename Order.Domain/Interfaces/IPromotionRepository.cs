using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
   
    public interface IPromotionRepository
    {
       
        Task SaveChanges();
       
        Task Add(Promotion promotion);
        
        Task Delete(int id);
        
        Task<List<Promotion>> GetAll();
        
        Task<Promotion> GetById(int id);
        
        Task Update(Promotion promotion, List<int> productIds);
    }
}
