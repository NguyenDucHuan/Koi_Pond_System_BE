using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;

namespace KPCOS.Api.Service.Implement
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public Task GetOrderItemAsync(int orderItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateOrderItemStatus(int orderItemId, string status)
        {
            var orderItem = await _orderItemRepository.GetOrderItemAsync(orderItemId);
            if (orderItem == null)
            {
                throw new Exception("Order item not found");
            }
            orderItem.Status = status;
            await _orderItemRepository.UpdateOrderItemAsync(orderItem);
            return "Update order item status success";
        }
    }
}