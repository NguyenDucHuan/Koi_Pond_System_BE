using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KPCOS.Api.Service.Implement
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IPondRepository _pondRepository;
        private readonly IPondComponentRepository _pondComponentRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IPondRepository pondRepository, IPondComponentRepository pondComponentRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _pondRepository = pondRepository;
            _pondComponentRepository = pondComponentRepository;
        }
        public async Task<string> CreateOrder(CreateOrderRequest orderRequest)
        {
            var order = orderRequest.ToOrder();
            var pondCreate = await _pondRepository.AddPondAsync(order.Item3);
            foreach (var item in order.Item4)
            {
                item.PondId = pondCreate.Id;
                await _pondComponentRepository.AddPondComponentAsync(item);
            }
            order.Item1.DiscouId = null;
            var orderCreate = await _orderRepository.AddOrderAsync(order.Item1);
            foreach (var item in order.Item2)
            {
                item.PondId = pondCreate.Id;
                item.OrderId = orderCreate.Id;
                await _orderItemRepository.AddOrderItemAsync(item);
            }
            return "Create order success";

        }

        public async Task<GetOrderDetailResponse> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            var response = new GetOrderDetailResponse
            {
                Id = order.Id,
                CreateOn = order.CreateOn,
                Status = order.Status,
                TotalMoney = order.TotalMoney,
            };
            return response;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return orders;
        }

        public async Task<string> UpdateOrderStatus(int orderId, string status)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException("order ko tồn tại");
            }
            order.Status = status;
            await _orderRepository.UpdateOrderAsync(order);
            return "cập nhật thành công";
        }
    }
}