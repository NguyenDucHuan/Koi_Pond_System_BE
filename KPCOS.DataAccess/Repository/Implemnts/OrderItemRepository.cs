using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly KpcosdbContext _context;

        public OrderItemRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem == null)
            {
                throw new Exception("OrderItem not found");
            }
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> GetOrderItemAsync(int orderItemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderItemId);
            if (orderItem == null)
            {
                return null;
            }
            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            var orderItems = await _context.OrderItems.ToListAsync();
            if (orderItems == null)
            {
                return null;
            }
            return orderItems;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem)
        {
            var orderItem1 = await _context.OrderItems.FindAsync(orderItem.Id);
            if (orderItem1 == null)
            {
                throw new Exception("OrderItem not found");
            }
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }
    }
}