using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IAuthService
    {
        // Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginResquest model);
        Task<string> GenerateTokenAsync(Account account);
    }
}