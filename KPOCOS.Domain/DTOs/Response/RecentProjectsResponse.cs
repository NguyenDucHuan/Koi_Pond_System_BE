using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class RecentProjectsResponse
    {
        public int OrderId { get; set; } 
        public string PondName { get; set; } 
        public string Client { get; set; } 
        public string Status { get; set; } 
        public string LastName { get; set; } 
        public string FirstName { get; set; }
    }
}
