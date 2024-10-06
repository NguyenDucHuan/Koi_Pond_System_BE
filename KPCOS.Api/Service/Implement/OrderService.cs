using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<Order> CreateOrder(Order order)
        {
            try
            {
                var orderCreate = _orderRepository.AddOrderAsync(order);
                return orderCreate;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Order> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByStatus(int status)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}