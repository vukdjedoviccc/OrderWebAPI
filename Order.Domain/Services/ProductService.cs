using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom proizvoda kako bi se pristupilo bazi
    /// </summary>
    public class ProductService : IProductService
    {
        // <summary>
        /// Properti repozitorijuma proizvoda koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Konstruktor sa parametrom repozitorijuma proizvoda koji inicijalizuje ovaj repozitorijum
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(Product product)
        {
            await _productRepository.Add(product); 
            await _productRepository.SaveChanges(); 
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
            await _productRepository.SaveChanges();
        }

        public async Task<List<Product>> GetAll()
        {
            return  await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
            await _productRepository.SaveChanges();
        }
    }
}
