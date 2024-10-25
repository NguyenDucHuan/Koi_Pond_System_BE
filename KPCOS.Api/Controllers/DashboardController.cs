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
        private readonly IOrderService _orderService;

        public DashboardController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [ProducesResponseType(typeof(GetDashboardStatsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GetDashboardStats(DateTime dateTimestart, DateTime dateTimeEnd)
        {

            var response = _orderService.GetDashboardStatsResponse(dateTimestart, dateTimeEnd);
            return Ok(response);
        }
        [ProducesResponseType(typeof(RevenueDahboardResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("dashboard-revenue")]
        public async Task<IActionResult> GetDashboardRevenue(DateTime dateTimestart, DateTime dateTimeEnd)
        {
            var response = _orderService.GetDashboardRevenueRes(dateTimestart, dateTimeEnd);
            return Ok(response);
        }
        [ProducesResponseType(typeof(RevenueDahboardResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("dashboard-ponds")]
        public async Task<IActionResult> GetDashboardPonds(DateTime dateTimestart, DateTime dateTimeEnd, int curentPage, int numpage)
        {
            var response = _orderService.GetDashboardPondsRes(dateTimestart, dateTimeEnd, curentPage, numpage);
            return Ok(response);
        }
    }
}
