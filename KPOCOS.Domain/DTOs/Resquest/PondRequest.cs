using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    internal class PondRequest
    {
        public string PondName { get; set; } 
        public decimal Decription { get; set; }
        public int PondDepth { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public string Shape { get; set; }

    }
}
