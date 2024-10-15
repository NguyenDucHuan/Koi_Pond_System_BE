using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/pond")]
    [ApiController]
    public class PondController : Controller
    {
        private readonly IPondService _pondService;

        public PondController(IPondService pondService)
        {
            _pondService = pondService;
        }

        [HttpGet("ponds")]
        public async Task<IActionResult> GetPonds()
        {
            try
            {
                var ponds = await _pondService.GetPondsAsync();
                return Ok(ponds);
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

        [HttpGet("pond/{id}")]
        public async Task<IActionResult> GetPondById([FromRoute] int id)
        {
            try
            {
                var pond = await _pondService.GetPondAsync(id);
                return Ok(pond);
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

        [ProducesResponseType(typeof(CreatePondRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager, PermissionAuthorizeConstant.Customer)]
        [HttpPost("add-pond")]
        public async Task<IActionResult> AddPond([FromBody] CreatePondRequest request)
        {

            var result = await _pondService.AddPondAsync(request);
            return Ok("oke");
        }
    }
}