using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    /// <summary>
    /// Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom narudžbine kako bi se pristupilo bazi
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Properti interfejsa repozitorijuma narudžbine koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IOrderRepository _orderRepository;
        /// <summary>
        /// Properti repozitorijuma proizvoda koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Konstruktor sa parametrima repozitorijuma narudžbine i proizvoda koje inicijalizuje ovaj repozitorijum
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="productRepository"></param>
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<Model.Order> GetById(int id)
        {
           return await _orderRepository.GetById(id);
        }

        public async Task<List<Model.Order>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }
        public async Task Add(Model.Order order)
        {
            var order1 = await SetOrder(order);
            await _orderRepository.Add(order1);
            await _orderRepository.SaveChanges();
        }

        public async Task Update(Model.Order order)
        {
            var order1 = await SetOrder(order);
            await _orderRepository.Update(order1);
            await _orderRepository.SaveChanges();
        }

        /// <summary>
        /// Metoda koja postavlja vrednosti narudžbine
        /// </summary>
        /// <param name="order"></param>
        private async Task<Model.Order> SetOrder(Model.Order order)
        {
            var productsFromDB = await _productRepository.ReturnProductsFromDB(order.OrderItems);
            foreach (var item in order.OrderItems)
            {
                item.Product = productsFromDB.FirstOrDefault(p => p.Id == item.ProductId);
            }
            order.CalculateTotalAmount();
            return order;
        }
    }
}
