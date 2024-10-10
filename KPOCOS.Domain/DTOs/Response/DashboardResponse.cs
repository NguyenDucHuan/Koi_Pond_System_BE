using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class DashboardResponse
    {
        public int TotalProjects { get; set; }
        public int OngoingProjects { get; set; }
        public int CompletedProjects { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCosts { get; set; }
        public int TotalClients { get; set; }
        public int TotalEmployees { get; set; }
        public List<RevenueResponse> MonthlyRevenueData { get; set; }
    }
}
