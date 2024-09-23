using KPCOS.Api.Attributes;
using KPCOS.Api.Constants;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountService _accountService;

        public AuthenticateController(IAuthService authService, IAccountService accountService)
        {
            _authService = authService;
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResquest loginRequest)
        {
            try
            {
                var (accountId, token) = await _authService.Login(loginRequest);
                var account = await _accountService.GetAccountById(accountId);
                var accountResponse = account.ToAccountDto();
                accountResponse.AccessToken = token;

                // Set token in cookie
                Response.Cookies.Append("AccessToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(30) // Matching token expiration
                });

                return Ok(accountResponse);
            }
            catch (NotFoundException)
            {
                return Unauthorized(MessageConstant.LoginConstants.InvalidUsernameOrPassword);
            }
            catch (BadRequestException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(PermissionAuthorizeConstant.Manager, PermissionAuthorizeConstant.Customer, PermissionAuthorizeConstant.ConsultingStaff, PermissionAuthorizeConstant.DesignStaff, PermissionAuthorizeConstant.ConstructionStaff)]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AccessToken");
            return Ok(new { Message = "Logged out successfully" });
        }
    }
}
