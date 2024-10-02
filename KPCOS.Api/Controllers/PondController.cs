using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Implement;
using KPOCOS.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/pond")]
    [ApiController]
    public class PondController : Controller
    {
        private readonly Pondservice _pondService;

        public PondController(Pondservice pondService)
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
    }
}