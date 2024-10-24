using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class CreateOrderRequest
    {
        public int AccountID { get; set; }
        public List<OrderItemRequest> OrderItems { get; set; }
        public string Status { get; set; } = null!;
        public int? DiscouId { get; set; }
        public decimal TotalMoney { get; set; }

    }

    public class OrderItemRequest
    {
        public int ServiceID { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public CreatePondRequest Pond { get; set; }
    }
}