using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> GetOrderItemAsync(int orderItemId);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem);
        Task DeleteOrderItemAsync(int orderItemId);
    }
}