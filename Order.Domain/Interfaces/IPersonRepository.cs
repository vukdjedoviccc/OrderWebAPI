using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    /// <summary>
    /// Interfejs koji sadrži sve metode za rad sa bazom kada su objekti osobe u pitanju
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Metoda koja čuva izmene u bazi
        /// </summary>
        Task SaveChanges();
        /// <summary>
        /// Metoda koja dodaje osobu u bazu
        /// </summary>
        /// <param name="person"></param>
        Task Add(Person person);
        /// <summary>
        /// Metoda koja briše osobu iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);
        /// <summary>
        /// Metoda koja vraća listu svih osoba iz baze
        /// </summary>
        Task<List<Person>> GetAll();
        /// <summary>
        /// Metoda koja vraća konkretnu osobu iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task<Person> GetById(int id);
        /// <summary>
        /// Metoda koja ažurira osobu u bazi
        /// </summary>
        /// <param name="person"></param>
        Task Update(Person person);
    }
}
