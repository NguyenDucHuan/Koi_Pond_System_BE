using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IAccountService
    {
        Task<GetAccountRespone> GetAccountById(int id);
        // ... các phương thức hiện có ...
        Task<GetAccountsRespone> GetAccountsAsync();
        Task<Account> GetByUserName(string username);

        Task<string> UpdateAccountStatus(string value);

        Task<string> UpdateAccount(int id, UpdateAccountRequest request);
        Task<GetUserProfileResponse> GetUserProfile(int id);
        Task<string> AddAccount(AddAccountRequest request);
        Task<GetAccountRespone> GetAccountByOrderId(int orderId);
    }
}
