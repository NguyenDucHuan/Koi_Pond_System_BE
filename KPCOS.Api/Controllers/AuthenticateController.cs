using KPCOS.Api.Attributes;
using KPCOS.Api.Constants;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Cors;
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

                var accountResponse = await _authService.Login(loginRequest);

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

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AccessToken");
            return Ok(new { Message = "Logged out successfully" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            try
            {
                var message = await _authService.Register(request);
            }
            catch (BadRequestException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(new { Message = "Register successfully" });
        }

        [HttpGet("verify-email")]
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string email)
        {
            try
            {
                await _authService.VerifyEmail(email);
                return Ok("Email đã được xác thực thành công");
            }
            catch (NotFoundException)
            {
                return NotFound("Không tìm thấy người dùng");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi xác thực email");
            }
        }
    }
}
