using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Order.Domain.Services
{
   
    public interface IOrderService
    {
       
        Task<List<Model.Order>> GetAll();
        
        Task<Model.Order> GetById(int id);
        
        Task Delete(int id);
        
        Task Add(Model.Order order);
        
        Task Update(Model.Order order);
    }
}
