using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IAuthService
    {
        // Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<AccountResponse> Login(LoginResquest model);
        Task<string> GenerateTokenAsync(Account account);
        Task<string> Register(RegisterDto request);
        Task VerifyEmail(string email);
        Task ForgotPassword(string value);
    }
}