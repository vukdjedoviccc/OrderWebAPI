using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
   
    public interface IProductService
    {
       
        Task AddProduct(Product product);
        
        Task<Product> GetById(int id);
        
        Task<List<Product>> GetAll();
        
        Task Delete(int id);
        
        Task Update(Product product);
    }
}
