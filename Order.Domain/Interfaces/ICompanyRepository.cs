using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    /// <summary>
    /// Interfejs koji sadrži sve metode za rad sa bazom kada su objekti kompanija u pitanju
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// Metoda koja čuva izmene u bazi
        /// </summary>
        Task SaveChanges();
        /// <summary>
        /// Metoda koja dodaje kompaniju u bazu
        /// </summary>
        /// <param name="company"></param>
        Task Add(Company company);
        /// <summary>
        /// Metoda koja briše konkretnu kompaniju iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);
        /// <summary>
        /// Metoda koja vraća listu svih kompanija iz baze
        /// </summary>
        Task<List<Company>> GetAll();
        /// <summary>
        /// Metoda koja vraća konkretnu kompaniju iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task<Company> GetById(int id);
        /// <summary>
        /// Metoda koja ažurira kompaniju u bazi
        /// </summary>
        /// <param name="company"></param>
        Task Update(Company company);
    }
}
