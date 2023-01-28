using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
   
    public interface IProductRepository
    {
       
        Task SaveChanges();

       
        Task Add(Product product);

       
        Task Delete(int id);

        
        Task<List<Product>> GetAll();

       
        Task<Product> GetById(int id);

        
        Task<List<Model.Product>> ReturnProductsFromDB(List<OrderItem> orderItems);

        
        Task Update(Product product);
    }
}
