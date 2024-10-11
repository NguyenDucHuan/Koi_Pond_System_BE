using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetComponentResponse
    {
        public int Id { get; set; }
        public string Decription { get; set; }
        public string Name { get; set; } = null!;
        public decimal PricePerItem { get; set; }
        public string Image { get; set; }
        public string Unit { get; set; }
    }
}