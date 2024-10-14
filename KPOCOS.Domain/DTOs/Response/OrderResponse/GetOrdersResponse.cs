using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetOrdersResponse
    {
        public List<GetOrderResponse> orders { get; set; } = new List<GetOrderResponse>();
    }
}