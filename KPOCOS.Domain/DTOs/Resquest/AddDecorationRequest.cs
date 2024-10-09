using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class AddDecorationRequest
    {
        public string? DecorationName { get; set; }

        public string? Decription { get; set; }

        public int? DecorationTypeId { get; set; }

        public decimal? PricePerSquareMeter { get; set; }
    }
}