using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts = await _accountService.GetAccountsAsync();
                return Ok(accounts);
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

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccountById([FromRoute] int id)
        {
            try
            {
                var account = await _accountService.GetAccountById(id);
                return Ok(account);
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