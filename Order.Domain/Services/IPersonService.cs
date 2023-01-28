using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Interfejs koji sadrži sve metode servisa za rad sa repozitorijumom osobe
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u nju dodala osobu
        /// </summary>
        /// <param name="person"></param>
        Task Add(Person person);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila konkretnu osobu na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param
        Task<Person> GetById(int id);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje vratila listu svih osoba
        /// </summary>
        Task<List<Person>> GetAll();
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi iz nje obrisala konkretnu osobu na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);
        /// <summary>
        /// Metoda koja pomoću repozitorijuma pristupa bazi kako bi u njoj ažurirala osobu
        /// </summary>
        /// <param name="person"></param>
        Task Update(Person person);
    }
}
