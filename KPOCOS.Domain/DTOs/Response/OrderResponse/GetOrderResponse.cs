using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public string Status { get; set; } = null!;
        public decimal TotalMoney { get; set; }
    }
    public class GetOrderItemResponse
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
    }
    public class GetOrderDetailResponse
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public string Status { get; set; } = null!;
        public decimal TotalMoney { get; set; }
        public List<GetOrderItemResponse> OrderItems { get; set; } = new List<GetOrderItemResponse>();
    }
    public class DashboardCol
    {
        public string Time { get; set; }
        public decimal Money { get; set; }
    }
}