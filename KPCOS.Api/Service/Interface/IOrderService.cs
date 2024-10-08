using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int id);

        Task<List<Order>> GetOrdersAsync();

        Task<Order> CreateOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order> DeleteOrder(int id);

        Task<Order> GetOrderByAccountId(int accountId);

        Task<Order> GetOrderByStatus(int status);


    }
}