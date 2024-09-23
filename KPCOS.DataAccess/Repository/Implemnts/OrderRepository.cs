using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KpcosdbContext _context;

        public OrderRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}