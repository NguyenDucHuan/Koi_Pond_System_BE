using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IAccountService
    {
        Task<Account> GetAccountById(int id);
        // ... các phương thức hiện có ...
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetByUserName(string username);
    }
}
