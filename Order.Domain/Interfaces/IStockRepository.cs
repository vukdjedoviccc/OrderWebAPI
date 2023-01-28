using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    public interface IStockRepository
    {
        
        Task SaveChanges();

        
        Task<Stock> GetById(int id);

        
        Task<List<Stock>> GetAll();

        
        Task Update(Stock stock);

       
        Task Add(Stock stock);
    }
}
