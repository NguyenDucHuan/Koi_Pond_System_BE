using KPCOS.Api.Enums;
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
                RoleId = (int)RoleEnum.Customer,
                Status = false
            };
        }

        public static void ToUpdateAccount(this UpdateAccountRequest request, Account account, int rollID)
        {
            account.UserName = request.UserName;
            var userProfile = account.UserProfiles.FirstOrDefault();

            if (userProfile != null)
            {
                userProfile.FirstName = request.FirstName;
                userProfile.LastName = request.LastName;
                userProfile.Email = request.Email;
                userProfile.Phone = request.Phone;
                userProfile.Birthday = request.Birthday ?? default(DateOnly);
                userProfile.Gender = request.Gender;
            }
            account.RoleId = rollID;
        }

        public static (Account, UserProfile) ToAddAccountRequest(this AddAccountRequest request)
        {
            return (new Account
            {
                UserName = request.UserName,
                Password = request.Password,
                RoleId = (int)Enum.Parse(typeof(RoleEnum), request.RoleName),
                Status = request.Status
            }, new UserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Birthday = request.Birthday ?? default(DateOnly),
                Gender = request.Gender
            });
        }

        public static GetUserProfileResponse ToGetUserProfileResponse(this Account account)
        {
            return new GetUserProfileResponse
            {
                ponds = account.Ponds.ToList().ToGetPondsResponse(),
                account = account.ToGetAccountRespone(),
                orders = account.Orders.ToList().ToGetOrdersResponse(),
            };
        }

        public static List<GetPondResponse> ToGetPondsResponse(this List<Pond> ponds)
        {
            return ponds.Select(p => new GetPondResponse
            {
                Id = p.Id,
                PondName = p.PondName,
                Decription = p.Decription,
                PondDepth = p.PondDepth,
                Area = p.Area,
                Location = p.Location,
                Shape = p.Shape,
                AccountId = p.AccountId ?? 0,
                DesignImage = p.DesignImage,

            }).ToList();
        }
        public static List<GetOrderResponse> ToGetOrdersResponse(this List<Order> orders)
        {
            return orders.Select(o => new GetOrderResponse
            {
                Id = o.Id,
                CreateOn = o.CreateOn,
                Status = o.Status,
                TotalMoney = o.TotalMoney
            }).ToList();
        }
    }
}
