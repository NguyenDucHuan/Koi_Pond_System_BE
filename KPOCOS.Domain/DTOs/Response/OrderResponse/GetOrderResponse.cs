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
}