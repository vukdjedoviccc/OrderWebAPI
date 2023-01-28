using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    public interface IStockService
    {
        
        Task Update(Stock stock);

       
        Task<Stock> GetById(int id);

       
        Task<List<Stock>> GetAll();

        
        Task Add(Stock stock);
    }
}
