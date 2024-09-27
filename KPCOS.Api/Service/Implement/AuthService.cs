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
using KPCOS.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace KPCOS.Api.Service.Implement
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IEmailService _emailService;

        public AuthService(IAccountRepository accountRepository, IConfiguration configuration, IUserProfileRepository userProfileRepository, IEmailService emailService)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _userProfileRepository = userProfileRepository;
            _emailService = emailService;
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

        public async Task<string> Register([FromBody] RegisterDto request)
        {
            var user = await _accountRepository.GetByUserName(request.registerAccount.UserName);
            if (user != null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.ExistUserName);
            }
            if (request.registerAccount.Password != request.registerAccount.ConfirmPassword)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.PasswordNotMatch);
            }
            var email = await _userProfileRepository.CheckEmail(request.registerUserProfile.Email);
            if (email != null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.EmailHaveRegistered);
            }
            var account = request.RegisToAccount();

            var userprofile = request.registerUserProfile.RegisToProfile();

            var userres = await _accountRepository.AddAccountAsync(account);
            if (userres == null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.RegisterFailed);
            }
            Console.WriteLine("................................................................................................");
            Console.WriteLine(userres.Id);
            Console.WriteLine(userprofile.AccountId);
            userprofile.AccountId = userres.Id;

            var profile = await _userProfileRepository.AddUserProfileAsync(userprofile);
            Console.WriteLine("................................................................................................");
            Console.WriteLine(profile.AccountId);
            Console.WriteLine(profile.Birthday);
            Console.WriteLine(profile.Email);
            Console.WriteLine(profile.FirstName);
            Console.WriteLine(profile.LastName);
            Console.WriteLine(profile.Phone);
            Console.WriteLine(profile.Gender);
            Console.WriteLine("................................................................................................");
            if (profile == null)
            {
                await _accountRepository.DeleteAccountAsync(userres.Id);
                throw new BadRequestException(MessageConstant.RegisterConstants.RegisterFailed);
            }
            // Gửi email xác thực
            // await SendVerificationEmail(request.registerUserProfile.Email);
            return MessageConstant.RegisterConstants.RegisterSuccess;
        }

        public async Task VerifyEmail(string email)
        {
            var userProfile = await _userProfileRepository.CheckEmail(email);
            if (userProfile == null)
            {
                throw new NotFoundException("Không tìm thấy hồ sơ người dùng");
            }

            var account = await _accountRepository.GetAccountAsync(userProfile.AccountId);
            if (account == null)
            {
                throw new NotFoundException("Không tìm thấy tài khoản liên kết");
            }

            if (account.Status)
            {
                throw new BadRequestException("Email đã được xác thực");
            }

            account.Status = true;
            await _accountRepository.UpdateAccountAsync(account);
        }

        private async Task SendVerificationEmail(string email)
        {
            var verifyUrl = $"{_configuration["AppUrl"]}/verify-email?email={Uri.EscapeDataString(email)}";

            var emailBody = $@"
                <h2>Xác nhận địa chỉ email của bạn</h2>
                <p>Vui lòng nhấp vào nút bên dưới để xác nhận địa chỉ email của bạn:</p>
                <a href='{verifyUrl}' style='display:inline-block;padding:10px 20px;background-color:#007bff;color:#ffffff;text-decoration:none;border-radius:5px;'>Xác nhận Email</a>
            ";

            await _emailService.SendEmailAsync(email, "Xác nhận địa chỉ email", emailBody, true);
        }

        private string GenerateVerificationToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}