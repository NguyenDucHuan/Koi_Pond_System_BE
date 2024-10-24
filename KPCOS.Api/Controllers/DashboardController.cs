using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{

    [ApiController]
    [Route("api/v1/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly OrderService _orderService;

        public DashboardController(OrderService _orderService)
        {
            _orderService = _orderService;
        }

        [ProducesResponseType(typeof(GetAccountRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GetDashboardStats()
        {
            try
            {
                // var totalOrders = await _orderService.GetTotalOrdersCountAsync();
                // var ongoingOrders = await _orderService.GetOngoingOrdersCountAsync();
                // var totalRevenue = await _orderService.GetTotalRevenueAsync();
                // var totalClients = await _orderService.GetTotalClientsCountAsync();

                // var stats = new
                // {
                //     totalOrders,
                //     ongoingOrders,
                //     totalRevenue,
                //     totalClients
                // };

                return Ok("ok");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
