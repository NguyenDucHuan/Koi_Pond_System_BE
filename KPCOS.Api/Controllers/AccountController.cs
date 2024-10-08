using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
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



        public ManagerController(IPondService pondService, IAccountService accountService)
        {
            _pondService = pondService;
            _accountService = accountService;

        }
        [ProducesResponseType(typeof(GetAccountsRespone), StatusCodes.Status200OK)]
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


    }
}