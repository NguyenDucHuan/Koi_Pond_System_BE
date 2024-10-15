using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class CreateComponentRequest
    {
        public string Name { get; set; } = null!;
        public string? Decription { get; set; }
        public decimal PricePerItem { get; set; }

        public int ComponentTypeId { get; set; }

        public string? Image { get; set; }

        public string? Unit { get; set; }
    }
}