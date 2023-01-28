using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
   
    public class StockService : IStockService
    {
        
        private readonly IStockRepository _stockRepository;
        

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock> GetById(int id)
        {
            return await _stockRepository.GetById(id);
        }

        public async Task Update(Stock stock)
        {
            await _stockRepository.Update(stock);
            await _stockRepository.SaveChanges();
        }

        public async Task Add(Stock stock)
        {
            await _stockRepository.Add(stock);
            await _stockRepository.SaveChanges();
        }

        public async Task<List<Stock>> GetAll()
        {
            return await _stockRepository.GetAll();
        }
    }
}
