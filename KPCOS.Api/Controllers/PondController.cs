using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Implement;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
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
        [ProducesResponseType(typeof(List<GetPondDetailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [HttpGet("ponds")]
        public async Task<IActionResult> GetPonds()
        {
            var ponds = await _pondService.GetPondsAsync();
            return Ok(ponds);
        }
        [ProducesResponseType(typeof(GetPondDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [HttpGet("pond/{id}")]
        public async Task<IActionResult> GetPondById([FromRoute] int id)
        {

            var pond = await _pondService.GetPondAsync(id);
            return Ok(pond);
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