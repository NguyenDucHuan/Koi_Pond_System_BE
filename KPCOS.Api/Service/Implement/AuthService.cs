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
using KPOCOS.Domain.DTOs.Account;
using KPCOS.Api.Untils;

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

        public async Task<AccountResponse> Login(LoginResquest model)
        {
            try
            {
                var account = await _accountRepository.GetByUserName(model.UserName);
                if (account == null)
                {
                    throw new NotFoundException(MessageConstant.LoginConstants.InvalidUsernameOrPassword);
                }
                if (account != null && account.Status == false)
                {
                    throw new BadRequestException(MessageConstant.LoginConstants.DeactivatedAccount);
                }
                if (account != null && account.Password != model.Password)
                {
                    throw new NotFoundException(MessageConstant.LoginConstants.InvalidUsernameOrPassword);
                }

                var token = await GenerateTokenAsync(account);
                var accountResponse = account.ToAccountDto();
                accountResponse.AccessToken = token;
                return accountResponse;
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("Tên đăng nhập", ex.Message);
                throw new NotFoundException(error);
            }
            catch (BadRequestException ex)
            {
                string fieldName = "";
                if (ex.Message.Equals(MessageConstant.LoginConstants.InvalidUsernameOrPassword) ||
                    ex.Message.Equals(MessageConstant.LoginConstants.DeactivatedAccount))
                {
                    fieldName = "Login Failed";
                }
                string error = ErrorUtil.GetErrorString(fieldName, ex.Message);
                throw new BadRequestException(error);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
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
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Register([FromBody] RegisterDto request)
        {
            try
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

                userprofile.AccountId = userres.Id;

                var profile = await _userProfileRepository.AddUserProfileAsync(userprofile);
                if (profile == null)
                {
                    await _accountRepository.DeleteAccountAsync(userres.Id);
                    throw new BadRequestException(MessageConstant.RegisterConstants.RegisterFailed);
                }
                // Gửi email xác thực
                // await SendVerificationEmail(request.registerUserProfile.Email);
                return MessageConstant.RegisterConstants.RegisterSuccess;
            }
            catch (BadRequestException ex)
            {
                string fieldName = "";
                if (ex.Message.Equals(MessageConstant.RegisterConstants.ExistUserName) ||
                    ex.Message.Equals(MessageConstant.RegisterConstants.PasswordNotMatch) ||
                    ex.Message.Equals(MessageConstant.RegisterConstants.EmailHaveRegistered) ||
                    ex.Message.Equals(MessageConstant.RegisterConstants.RegisterFailed))
                {
                    fieldName = "Register Failed";
                }
                string error = ErrorUtil.GetErrorString(fieldName, ex.Message);
                throw new BadRequestException(error);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }

        public async Task VerifyEmail(string email)
        {
            try
            {

                var userProfile = await _userProfileRepository.CheckEmail(email);
                if (userProfile == null)
                {
                    throw new NotFoundException(MessageConstant.VerifyEmailConstants.UserProfileNotFound);
                }

                var account = await _accountRepository.GetAccountAsync(userProfile.AccountId);
                if (account == null)
                {
                    throw new NotFoundException(MessageConstant.VerifyEmailConstants.AccountNotFound);
                }

                if (account.Status == true)
                {
                    throw new BadRequestException(MessageConstant.VerifyEmailConstants.EmailVerified);
                }

                account.Status = true;
                await _accountRepository.UpdateAccountAsync(account);
            }
            catch (BadRequestException ex)
            {
                string fieldName = "";
                if (ex.Message.Equals(MessageConstant.VerifyEmailConstants.EmailVerified))
                {
                    fieldName = "Xác thực email thất bại";
                }
                string error = ErrorUtil.GetErrorString(fieldName, ex.Message);
                throw new BadRequestException(error);
            }
            catch (NotFoundException ex)
            {
                string fieldName = "";
                if (ex.Message.Equals(MessageConstant.VerifyEmailConstants.UserProfileNotFound))
                {
                    fieldName = "Xác thực email thất bại";
                }
                else if (ex.Message.Equals(MessageConstant.VerifyEmailConstants.AccountNotFound))
                {
                    fieldName = "Xác thực email thất bại";
                }
                string error = ErrorUtil.GetErrorString(fieldName, ex.Message);
                throw new NotFoundException(error);
            }

            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
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