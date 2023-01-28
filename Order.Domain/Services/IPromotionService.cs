using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom promocije
    /// </summary>
    public interface IPromotionService
    {
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu promociju na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param
        Task<Promotion> GetById(int id);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih promocija
        /// </summary>
        Task<List<Promotion>> GetAll();
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala promociju sa njoj odgovarajućim proizvodima
        /// </summary>
        /// <param name="promotion"></param>
        /// <param name="productIds"></param>
        Task Add(Promotion promotion, List<int> productIds);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu promociju na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task DeleteById(int id);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala promociju sa njoj odgovarajućim proizvodima
        /// </summary>
        /// <param name="promotion"></param>
        /// <param name="productIds"></param>
        Task Update(Promotion promotion, List<int> productIds);
    }
}
