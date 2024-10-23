using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IOrderService
    {
        Task<String> CreateOrder(CreateOrderRequest orderRequest);
        Task<GetOrderDetailResponse> GetOrderAsync(int orderId);
        Task<string> UpdateOrderStatus(int orderId, string status);
    }
}