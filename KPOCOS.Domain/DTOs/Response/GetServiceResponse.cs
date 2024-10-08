using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetServiceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Decription { get; set; }
        public decimal PricePerM2 { get; set; }
    }
}