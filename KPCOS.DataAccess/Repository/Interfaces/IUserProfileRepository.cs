using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetUserProfilesAsync();
        Task<UserProfile> GetUserProfileAsync(int userProfileId);
        Task<UserProfile> AddUserProfileAsync(UserProfile userProfile);
        Task<UserProfile> UpdateUserProfileAsync(UserProfile userProfile);
        Task DeleteUserProfileAsync(int userProfileId);
        Task<UserProfile> CheckEmail(string email);
    }
}