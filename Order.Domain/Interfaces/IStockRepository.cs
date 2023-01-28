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
        /// <summary>
        /// Metoda za čuvanje izmena u bazi
        /// </summary>
        Task SaveChanges();

        /// <summary>
        /// Metoda koja vraća konkretan red skladišta iz baze na osnovu njegovog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task<Stock> GetById(int id);

        /// <summary>
        /// Metoda koja vraća listu svih redova skladišta iz baze
        /// </summary>
        Task<List<Stock>> GetAll();

        /// <summary>
        /// Metoda koja ažurira red skladišta u bazi
        /// </summary>
        /// <param name="stock"></param>
        Task Update(Stock stock);

        /// <summary>
        /// Metoda koja dodaje red skladišta u bazu
        /// </summary>
        /// <param name="product"></param>
        Task Add(Stock stock);
    }
}
