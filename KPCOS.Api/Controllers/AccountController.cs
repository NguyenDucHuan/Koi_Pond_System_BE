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
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IPondService _pondService;
        private readonly IAccountService _accountService;



        public ManagerController(IPondService pondService, IAccountService accountService)
        {
            _pondService = pondService;
            _accountService = accountService;

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
        [ProducesResponseType(typeof(GetUserProfileResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [PermissionAuthorize(PermissionAuthorizeConstant.Manager, PermissionAuthorizeConstant.Customer)]
        [HttpPost("get-user-profile/{id}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] int id)
        {
            var userProfile = await _accountService.GetUserProfile(id);
            return Ok(userProfile);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        // [PermissionAuthorize(PermissionAuthorizeConstant.Manager, PermissionAuthorizeConstant.Customer)]
        [HttpPost("add-account")]
        public async Task<IActionResult> AddAccount([FromBody] AddAccountRequest request)
        {
            var account = await _accountService.AddAccount(request);
            return Ok(account);
        }

    }
}