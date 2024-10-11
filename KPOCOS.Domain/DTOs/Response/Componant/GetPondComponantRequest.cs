using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetPondComponantRequest
    {
        public int ComponentId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}