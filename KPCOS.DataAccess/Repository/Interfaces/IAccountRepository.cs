using KPOCOS.Domain.DTOs;
using KPOCOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(int accountId);
        Task<Account> AddAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task<Account> GetByUserName(string userName);
    }
}
