using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetDashboardStatsResponse
    {
        public int TotalProjects { get; set; }
        public int OngoingProjects { get; set; }
        public int CompletedProjects { get; set; }
        public double TotalRevenue { get; set; }
        public DateTime? TimeFillterStart { get; set; }
        public DateTime? TimeFillterEnd { get; set; }
    }
    public class GetCurrentPondDashboardResponse
    {
        public List<PondDashBoard> pondDashBoards { get; set; }
        public int totalPage { get; set; }
        public int curentPage { get; set; }
    }
    public class RevenueDahboardResponse
    {
        public List<DashboardCol> dashboards { get; set; }
    }
}
