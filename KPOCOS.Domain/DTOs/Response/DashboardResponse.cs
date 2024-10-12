using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    internal class DashboardResponse
    {
        public int TotalProjects { get; set; }
        public int OngoingProjects { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalClients { get; set; }
        public List<RecentProjectsResponse> RecentProjects { get; set; }
    }
}
