using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class UpdateOrderRequest
    {
        public int id { get; set; }
        public string status { get; set; }
        public decimal totalMoney { get; set; }

        public List<UpdateOrderItemRequest> orderItems { get; set; }


    }
    public class UpdateOrderItemRequest
    {
        public int id { get; set; }
        public decimal totalPrice { get; set; }
        public int serviceId { get; set; }
        public UpdateOrderPondRequest getPondDetailResponse { get; set; }
    }
    public class UpdateOrderPondRequest
    {
        public int id { get; set; }
        public string pondName { get; set; }
        public string location { get; set; }
        public decimal PondDepth { get; set; }
        public decimal Area { get; set; }
        public string shape { get; set; }
        public List<UpdatePondComponentRequest> components { get; set; }
    }
    public class UpdatePondComponentRequest
    {
        public int componentId { get; set; }
        public decimal amount { get; set; }
    }
}