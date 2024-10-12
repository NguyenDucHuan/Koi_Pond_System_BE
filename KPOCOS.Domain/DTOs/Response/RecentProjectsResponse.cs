using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class RecentProjectsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Status { get; set; }
    }
}
