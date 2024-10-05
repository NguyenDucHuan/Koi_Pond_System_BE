using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KpcosdbContext _context;

        public OrderRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var orderCheckExist = await _context.Orders.FindAsync(order.Id);
            if (orderCheckExist == null)
            {
                throw new Exception("Order not found");
            }
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}