using FluentValidation;
using FluentValidation.Results;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/material")]
    [ApiController]
    public class ComponentController : Controller
    {
        private readonly IComponentService _componentService;
        private IValidator<CreateComponentRequest> _createComponentValidator;
        public ComponentController(IComponentService componentService, IValidator<CreateComponentRequest> createComponentValidator)
        {
            _componentService = componentService;
            _createComponentValidator = createComponentValidator;
        }

        [ProducesResponseType(typeof(GetComponentsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("components")]
        public async Task<IActionResult> GetComponents()
        {
            var components = await _componentService.GetComponentsAsync();
            return Ok(components);
        }

        [ProducesResponseType(typeof(GetComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("component/{id}")]
        public async Task<IActionResult> GetComponentById([FromRoute] int id)
        {
            var component = await _componentService.GetComponentAsync(id);
            return Ok(component);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpPost("component")]
        public async Task<IActionResult> CreateComponent([FromBody] CreateComponentRequest createComponentRequest)
        {
            ValidationResult validationResult = await _createComponentValidator.ValidateAsync(createComponentRequest);
            if (validationResult.IsValid == false)
            {
                string errors = ErrorUtil.GetErrorsString(validationResult);
                throw new BadRequestException(errors);
            }
            await _componentService.AddComponentAsync(createComponentRequest);
            return Ok("Create component success");
        }


    }
}