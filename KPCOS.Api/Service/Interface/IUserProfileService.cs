using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IUserProfileService
    {
        Task<UserProfileResponse> GetUserProfileAsync(int userId);
        Task<bool> UpdateUserProfileAsync(int userId, UserProfileResponse profileDto);
        Task<bool> DeleteUserProfileAsync(int userId);
    }
}