using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(int orderId);
        Task<List<Order>> GetOrdersAsync();

        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
    }
}
