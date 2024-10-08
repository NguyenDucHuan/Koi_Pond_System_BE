using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Errors;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/display")]
    public class DisplayController : Controller
    {
        private readonly IServiceTypeService _servicetypeservice;

        public DisplayController(IServiceTypeService serviceTypeService)
        {
            _servicetypeservice = serviceTypeService;
        }
        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("services-display")]
        public async Task<IActionResult> GetAccounts()
        {
            GetServiceTypesResponse serviceTypes = await _servicetypeservice.GetServiceTypesAsync();
            return Ok(serviceTypes);
        }
    }
}