
using Order.Domain.Helper;
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
    
    public class OrderService : IOrderService
    {
        
        private readonly IOrderRepository _orderRepository;
        
        private readonly IProductRepository _productRepository;
        
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
            JSONHelper.WriteOrdersToJSONFile(orders);
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
