using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class CreatePondComponentRequest
    {
        public int ComponentId { get; set; }
        public decimal Amount { get; set; }
    }
}