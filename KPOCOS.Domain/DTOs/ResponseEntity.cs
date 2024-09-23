using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs
{
    public class ResponseEntity
    {
        public bool status { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
