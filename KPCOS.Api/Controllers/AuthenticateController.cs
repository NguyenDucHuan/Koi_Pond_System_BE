using FluentValidation;
using FluentValidation.Results;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using KPCOS.Api.Attributes;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;

        private IValidator<LoginResquest> _loginValidator;
        private IValidator<RegisterDto> _registerValidator;

        public AuthenticateController(IAuthService authService, IValidator<LoginResquest> loginValidator, IValidator<RegisterDto> registerValidator)
        {
            _authService = authService;

            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginResquest loginRequest)
        {
            ValidationResult validationResult = await _loginValidator.ValidateAsync(loginRequest);
            if (validationResult.IsValid == false)
            {
                string errors = ErrorUtil.GetErrorsString(validationResult);
                throw new BadRequestException(errors);
            }
            AccountResponse accountResponse = await _authService.Login(loginRequest);

            // Set token in cookie
            Response.Cookies.Append("AccessToken", accountResponse.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30) // Matching token expiration
            });

            return Ok(accountResponse);

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AccessToken");
            return Ok(new { Message = "Logged out successfully" });
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            ValidationResult validationResult = await _registerValidator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                string errors = ErrorUtil.GetErrorsString(validationResult);
                throw new BadRequestException(errors);
            }
            await _authService.Register(request);

            return Ok(new { Message = MessageConstant.RegisterConstants.RegisterSuccess });
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] string email)
        {
            await _authService.VerifyEmail(email);
            return Ok(new { Message = MessageConstant.EmailConstants.VerifyEmail });
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string value)
        {
            await _authService.ForgotPassword(value);
            return Ok(new { Message = MessageConstant.EmailConstants.ForgotPassword });
        }
    }
}