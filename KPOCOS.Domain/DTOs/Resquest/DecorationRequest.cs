using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    internal class DecorationRequest
    {
        public int Id { get; set; }

        public string? DecorationName { get; set; }

        public string? Decription { get; set; }

        public int? DecorationTypeId { get; set; }

        public decimal? PricePerSquareMeter { get; set; }
    }
}
