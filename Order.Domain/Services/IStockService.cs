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
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala red u skladištu(količinu proizvoda)
        /// </summary>
        /// <param name="stock"></param>
        Task Update(Stock stock);

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila red iz skladišta na osnovu id-ja
        /// </summary>
        /// <param name="stock"></param>
        Task<Stock> GetById(int id);

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila sve redove iz skladišta
        /// </summary>
        Task<List<Stock>> GetAll();

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala red iz skladišta(dodala novi proizvod u skladište)
        /// </summary>
        /// <param name="stock"></param>
        Task Add(Stock stock);
    }
}
