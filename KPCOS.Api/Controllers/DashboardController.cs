using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{

    [ApiController]
    [Route("api/v1/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly KpcosdbContext _context;

        public DashboardController(KpcosdbContext context)
        {
            _context = context;
        }

        [ProducesResponseType(typeof(GetAccountRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GetDashboardInfo()
        {
            try
            {
                var totalProjects = await _context.Ponds.CountAsync();
                var ongoingProjects = await _context.Orders.CountAsync(p => p.Status == "Đang tiến hành"); 
                var completedProjects = await _context.Orders.CountAsync(p => p.Status == "Hoàn thành"); 
                var totalRevenue = await _context.Orders.SumAsync(o => o.TotalMoney);
                var totalCosts = await _context.OrderItems.SumAsync(oi => oi.TotalPrice); 
                var totalClients = await _context.Accounts.CountAsync(a => a.RoleId == 2); 
                var totalEmployees = await _context.Accounts.CountAsync(a => a.RoleId == 1); 

                var monthlyRevenueData = await _context.Orders
                    .GroupBy(o => new { o.CreateOn.Year, o.CreateOn.Month })
                    .Select(g => new RevenueResponse
                    {
                        Month = $"{g.Key.Month}/{g.Key.Year}", 
                        Revenue = g.Sum(o => o.TotalMoney)
                    })
                    .ToListAsync();

                var dashboardData = new DashboardResponse
                {
                    TotalProjects = totalProjects,
                    OngoingProjects = ongoingProjects,
                    CompletedProjects = completedProjects,
                    TotalRevenue = totalRevenue,
                    TotalCosts = totalCosts,
                    TotalClients = totalClients,
                    TotalEmployees = totalEmployees,
                    MonthlyRevenueData = monthlyRevenueData 
                };

                return Ok(dashboardData);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
