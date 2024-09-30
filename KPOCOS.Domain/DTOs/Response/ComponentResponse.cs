using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    internal class ComponentResponse
    {
        public int Id { get; set; }

        public string? Decription { get; set; }

        public string Name { get; set; } = null!;

        public decimal PricePerItem { get; set; }

        public int ComponentTypeId { get; set; }
    }
}
