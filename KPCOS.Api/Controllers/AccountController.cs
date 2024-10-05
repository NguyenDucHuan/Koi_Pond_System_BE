using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using MBKC.Service.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
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