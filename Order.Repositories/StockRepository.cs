using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repositories
{
    /// <summary>
    /// Klasa koja predstavlja repozitorijum skladišta za pozivanje metoda koje rade direktno nad bazom
    /// </summary>
    public class StockRepository : IStockRepository
    {
        // <summary>
        /// Properti datacontext-a zaduženog za rad sa bazom
        /// </summary>
        private readonly DataContext _dataContext;
        /// <summary>
        /// Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje 
        /// </summary>
        /// <param name="dataContext"></param>
        public StockRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Stock> GetById(int id)
        {
            var record = await _dataContext.Stocks.Where(p => p.ProductId == id).AsNoTracking().FirstOrDefaultAsync();
            Stock stock = new Stock
            {
                Quantity = record.Quantity,
                Id = record.Id
            };
            return stock;
        }

        public async Task Update(Stock stock)
        {
            var record = new StockRecord
            {
               Id = stock.Id,
               ProductId = stock.ProductId,
               Quantity = stock.Quantity,
            };
            _dataContext.Stocks.Update(record);
        }

        public async Task Add(Stock stock)
        {
            var record = new StockRecord
            {
               ProductId = stock.Id,
               Quantity = stock.Quantity,
            };

            await _dataContext.Stocks.AddAsync(record);
        }

        public async Task<List<Stock>> GetAll()
        {
            var records = await _dataContext.Stocks.AsNoTracking().ToListAsync();
            List<Stock> stocks = records.Select(x => new Stock
            {
                Id = x.Id,
                ProductId= x.ProductId,
                Quantity = x.Quantity,
            }).ToList();
            return stocks;
        }
    }
}
