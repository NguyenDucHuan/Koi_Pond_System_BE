using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Response.Componant;
using KPOCOS.Domain.Errors;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/display")]
    [ApiController]
    public class DisplayController : Controller
    {
        private readonly IServiceTypeService _servicetypeservice;
        private readonly IComponentService _componentService;
        private readonly IPondService _pondService;
        public DisplayController(IServiceTypeService serviceTypeService, IComponentService componentService, IPondService pondService)
        {
            _servicetypeservice = serviceTypeService;
            _componentService = componentService;
            _pondService = pondService;
        }
        [ProducesResponseType(typeof(GetServiceTypesResponse), StatusCodes.Status200OK)]
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

        [ProducesResponseType(typeof(GetComponentTypesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("components-display")]
        public async Task<IActionResult> GetComponents()
        {
            var components = await _componentService.GetComponentsAsync();
            return Ok(components);
        }
        [ProducesResponseType(typeof(List<GetPondDetailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("ponds-display")]
        public async Task<IActionResult> GetPondSample()
        {
            var ponds = await _pondService.GetPondsDisplayAsync();
            return Ok(ponds);
        }
    }
}