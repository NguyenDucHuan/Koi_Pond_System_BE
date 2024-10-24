using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPCOS.Api.Service.Interface
{
    public interface IOrderItemService
    {
        Task GetOrderItemAsync(int orderItemId);
        Task<string> UpdateOrderItemStatus(int orderItemId, string status);
    }
}