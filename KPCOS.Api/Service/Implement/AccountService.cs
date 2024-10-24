using System.IdentityModel.Tokens.Jwt;
using System.Text;
using KPCOS.Api.Constants;
using KPCOS.Api.Enums;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.DTOs.Account;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;

namespace KPCOS.Api.Service.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public AccountService(IAccountRepository accountRepository, IUserProfileRepository userProfileRepository)
        {
            _accountRepository = accountRepository;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<string> AddAccount(AddAccountRequest request)
        {

            var user = await _accountRepository.GetByUserName(request.UserName);
            if (user != null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.ExistUserName);
            }
            var email = await _userProfileRepository.CheckEmail(request.Email);
            if (email != null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.EmailHaveRegistered);
            }
            var (account, userProfile) = request.ToAddAccountRequest();
            var userres = await _accountRepository.AddAccountAsync(account);
            if (userres == null)
            {
                throw new BadRequestException(MessageConstant.RegisterConstants.RegisterFailed);
            }
            userProfile.AccountId = userres.Id;
            var profile = await _userProfileRepository.AddUserProfileAsync(userProfile);
            if (profile == null)
            {
                await _accountRepository.DeleteAccountAsync(userres.Id);
                throw new BadRequestException(MessageConstant.RegisterConstants.RegisterFailed);
            }
            return "Add tài khoản thành công";
        }

        public async Task<GetAccountRespone> GetAccountById(int id)
        {
            try
            {

                var account = await _accountRepository.GetAccountAsync(id);
                if (account == null)
                {
                    throw new NotFoundException($"Tài khoản với id {id} không tồn tại");
                }
                var accountResponse = account.ToGetAccountRespone();

                return accountResponse;
            }
            catch (NotFoundException ex)
            {
                string fieldName = "";
                if (ex.Message.Contains("id"))
                {
                    fieldName = "Không tìm thấy tài khoản";
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

        public async Task<GetAccountsRespone> GetAccountsAsync()
        {
            try
            {
                var accounts = await _accountRepository.GetAccountsAsync();
                if (accounts == null)
                {
                    throw new NotFoundException("Account List is empty");
                }
                var getAccountsRespone = accounts.ToGetAccountsRespone();
                return getAccountsRespone;
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("Account List is empty", ex.Message);
                throw new NotFoundException(error);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }

        public async Task<Account> GetByUserName(string username)
        {
            var account = await _accountRepository.GetByUserName(username);
            if (account == null)
            {
                throw new NotFoundException($"Account with username {username} not found");
            }
            return account;
        }

        public async Task<GetUserProfileResponse> GetUserProfile(int id)
        {
            var account = await _accountRepository.GetAccountAsync(id);
            if (account == null)
            {
                throw new NotFoundException($"Account with id {id} not found");
            }
            var userProfile = account.ToGetUserProfileResponse();
            return userProfile;
        }

        public async Task<string> UpdateAccount(int id, UpdateAccountRequest request)
        {
            try
            {
                var account = await _accountRepository.GetAccountAsync(id);
                if (account == null)
                {
                    throw new NotFoundException($"Tài khoản với id {id} không tồn tại");
                }

                request.ToUpdateAccount(account, (int)Enum.Parse(typeof(RoleEnum), request.RoleName));


                await _accountRepository.UpdateAccountAsync(account);

                return MessageConstant.ManagerAccount.UpdateAccountSuccess;
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("Không tìm thấy", ex.Message);
                throw new NotFoundException(error);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }

        public async Task<string> UpdateAccountStatus(string value)
        {
            try
            {
                var account = await _accountRepository.GetByUserName(value);
                if (account == null)
                {
                    throw new NotFoundException($"Tài khoản với username {value} không tồn tại");
                }
                account.Status = !account.Status;

                await _accountRepository.UpdateAccountAsync(account);
                return MessageConstant.ManagerAccount.UpdateAccountStatusSuccess;
            }
            catch (NotFoundException ex)
            {
                string error = ErrorUtil.GetErrorString("Không tìm tháy", ex.Message);
                throw new NotFoundException(error);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }
    }
}


