using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    /// <summary>
    /// Interfejs koji sadrži sve metode za rad sa bazom kada su objekti proizvoda u pitanju
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Metoda za čuvanje izmena u bazi
        /// </summary>
        Task SaveChanges();

        /// <summary>
        /// Metoda koja dodaje proizvod u bazu
        /// </summary>
        /// <param name="product"></param>
        Task Add(Product product);

        /// <summary>
        /// Metoda koja briše proizvod iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);

        /// <summary>
        /// Metoda koja vraća listu svih proizvoda iz baze
        /// </summary>
        Task<List<Product>> GetAll();

        /// <summary>
        /// Metoda koja vraća konkretan proizvod iz baze na osnovu njegovog id-ja
        /// </summary>
        /// <param name="id"></param>
        Task<Product> GetById(int id);

        /// <summary>
        /// Metoda koja vraća listu proizvoda iz baze koji čine stavke narudžbine
        /// </summary>
        /// <param name="orderItems"></param>
        Task<List<Model.Product>> ReturnProductsFromDB(List<OrderItem> orderItems);

        /// <summary>
        /// Metoda koja ažurira proizvod u bazi
        /// </summary>
        /// <param name="product"></param>
        Task Update(Product product);
    }
}
