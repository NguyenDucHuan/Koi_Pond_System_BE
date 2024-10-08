using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Implement;
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
        private readonly OrderService _context;

        public DashboardController(OrderService context)
        {
            _context = context;
        }

        [ProducesResponseType(typeof(GetAccountRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("done-orders-count")]
        public async Task<IActionResult> GetOrdersCount()
        {
            try
            {
                var orders = await _context.GetOrdersAsync(); 
                var doneOrdersCount = orders.Where(o => o.Status == "done").Count();
                return Ok(doneOrdersCount);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
