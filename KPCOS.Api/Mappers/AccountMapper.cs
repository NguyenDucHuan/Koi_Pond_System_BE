using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class AccountMapper
    {
        public static AccountResponse ToAccountDto(this Account accountmodel)
        {
            return new AccountResponse
            {
                Id = accountmodel.Id,
                UserName = accountmodel.UserName,
                RoleName = accountmodel.Role.Type,
                AccessToken = null,
                Status = accountmodel.Status,
            };
        }
        public static Account RegisToAccount(this RegisterAccount registerAccount)
        {
            return new Account
            {
                UserName = registerAccount.UserName,
                Password = registerAccount.Password,
                RoleId = 2,
                Status = true
            };
        }
    }
}
