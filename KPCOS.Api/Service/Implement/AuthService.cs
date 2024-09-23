using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;
using KPCOS.Api.Constants;
using KPOCOS.Domain.Exceptions;
using KPCOS.DataAccess.Repository.Interfaces;

namespace KPCOS.Api.Service.Implement
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<(int, string)> Login(LoginResquest model)
        {
            var account = await _accountRepository.GetByUserName(model.UserName);
            if (account == null)
            {
                throw new NotFoundException(MessageConstant.LoginConstants.InvalidUsernameOrPassword);
            }
            if (account.Status == false)
            {
                throw new BadRequestException(MessageConstant.LoginConstants.DeactivatedAccount);
            }
            if (account.Password != model.Password)
            {
                throw new Exception("Password is incorrect");
            }

            var token = await GenerateTokenAsync(account);
            return (account.Id, token);
        }

        public async Task<string> GenerateTokenAsync(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, account.UserName),
                new Claim(ClaimTypes.Role, account.Role.Type)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}