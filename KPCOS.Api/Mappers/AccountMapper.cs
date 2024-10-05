using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Response;
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
                FirstName = accountmodel.UserProfiles.FirstOrDefault().FirstName,
                LastName = accountmodel.UserProfiles.FirstOrDefault().LastName,
            };
        }
        public static GetAccountsRespone ToGetAccountsRespone(this List<Account> accounts)
        {
            List<GetAccountRespone> getAccountRespones = new List<GetAccountRespone>();
            foreach (var item in accounts)
            {
                getAccountRespones.Add(item.ToGetAccountRespone());
            }
            return new GetAccountsRespone
            {
                Accounts = getAccountRespones
            };
        }
        public static GetAccountRespone ToGetAccountRespone(this Account account)
        {
            return new GetAccountRespone
            {
                Id = account.Id,
                UserName = account.UserName,
                FirstName = account.UserProfiles.FirstOrDefault().FirstName,
                LastName = account.UserProfiles.FirstOrDefault().LastName,
                Email = account.UserProfiles.FirstOrDefault().Email,
                Phone = account.UserProfiles.FirstOrDefault().Phone,
                Birthday = account.UserProfiles.FirstOrDefault()?.Birthday ?? default(DateOnly),
                Gender = account.UserProfiles.FirstOrDefault().Gender,
                Status = account.Status,
                RoleName = account.Role.Type
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
        public static Account RegisToAccount(this RegisterDto registerDto)
        {
            return new Account
            {
                UserName = registerDto.registerAccount.UserName,
                Password = registerDto.registerAccount.Password,
                RoleId = 2,
                Status = false
            };
        }

    }
}
