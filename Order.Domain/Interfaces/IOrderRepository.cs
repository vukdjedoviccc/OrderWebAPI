using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    
    public interface IOrderRepository
    {
        
        Task SaveChanges();
        
        Task Add(Domain.Model.Order order);
        
        Task Delete(int id);
        
        Task<Model.Order> GetById(int id);
        
        Task<List<Model.Order>> GetAll();
        
        Task Update(Model.Order order);
    }
}
