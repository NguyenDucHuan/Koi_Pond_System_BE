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
    [Route("api/v1/manager")]
    public class ManagerController : Controller
    {
        private readonly IPondService _pondService;
        private readonly IAccountService _accountService;
        private readonly IDecorationService _decorationService;
        private readonly IComponentService _componentService;

        public ManagerController(IPondService pondService, IAccountService accountService)
        {
            _pondService = pondService;
            _accountService = accountService;
        }

        [HttpGet("ponds")]
        public async Task<IActionResult> GetPonds()
        {
            var ponds = await _pondService.GetPondsAsync();
            return Ok(ponds);
        }

        [HttpGet("decorations")]
        public async Task<IActionResult> GetDecorations()
        {
            var decorations = await _decorationService.GetDecorationsAsync();
            return Ok(decorations);
        }

        [HttpGet("components")]
        public async Task<IActionResult> GetComponents()
        {
            var components = await _componentService.GetComponentsAsync();
            return Ok(components);
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

        // [HttpPost("accounts")]
        // public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountDto)
        // {
        //     try
        //     {
        //         var createdAccount = await _accountService.CreateAccount(accountDto);
        //         return CreatedAtAction(nameof(GetAccountById), new { id = createdAccount.Id }, createdAccount);
        //     }
        //     catch (BadRequestException ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }


    }
}