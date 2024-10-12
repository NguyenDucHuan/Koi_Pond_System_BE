using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/account-manager")]
    public class ManagerController : Controller
    {
        private readonly IPondService _pondService;
        private readonly IAccountService _accountService;
        private readonly IUserProfileService _userProfileService;


        public ManagerController(IPondService pondService, IAccountService accountService, IUserProfileService userProfileService)
        {
            _pondService = pondService;
            _accountService = accountService;
            _userProfileService = userProfileService;

        }
        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            GetAccountsRespone accounts = await _accountService.GetAccountsAsync();
            return Ok(accounts);
        }

        [ProducesResponseType(typeof(GetAccountRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccountById([FromRoute] int id)
        {

            GetAccountRespone account = await _accountService.GetAccountById(id);
            return Ok(account);

        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpPut("users/{username}/status")]
        public async Task<IActionResult> UpdateAccountStatus([FromRoute] string username)
        {
            var account = await _accountService.UpdateAccountStatus(username);
            return Ok(account);
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int id, [FromBody] UpdateAccountRequest request)
        {
            var account = await _accountService.UpdateAccount(id, request);
            return Ok(account);

        }

        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            var profile = await _userProfileService.GetUserProfileAsync(userId);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] UserProfileResponse profileDto)
        {
            if (userId != profileDto.UserID)
            {
                return BadRequest("User ID mismatch.");
            }

            var result = await _userProfileService.UpdateUserProfileAsync(userId, profileDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserProfile(int userId)
        {
            var result = await _userProfileService.DeleteUserProfileAsync(userId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}