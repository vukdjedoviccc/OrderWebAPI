using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom kompanije
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala kompaniju
        /// </summary>
        /// <param name="company"></param>
        Task Add(Company company);

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu kompaniju na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param
        Task<Company> GetById(int id);

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih kompanija
        /// </summary>
        Task<List<Company>> GetAll();

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu kompaniju na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);

        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala kompaniju
        /// </summary>
        /// <param name="company"></param>
        Task Update(Company company);
    }
}
