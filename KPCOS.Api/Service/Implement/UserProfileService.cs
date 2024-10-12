using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Models;

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public async Task<UserProfileResponse> GetUserProfileAsync(int userId)
    {
        var profile = await _userProfileRepository.GetUserProfileAsync(userId);

        if (profile == null) return null;

        return new UserProfileResponse
        {
            UserID = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Phone = profile.Phone,
            Birthday = profile.Birthday,
            Gender = profile.Gender,
            Email = profile.Email
        };
    }

    public async Task<UserProfileResponse> AddUserProfileAsync(UserProfileResponse profileDto)
    {
        var newProfile = new UserProfile
        {
            FirstName = profileDto.FirstName,
            LastName = profileDto.LastName,
            Phone = profileDto.Phone,
            Birthday = profileDto.Birthday,
            Gender = profileDto.Gender,
            Email = profileDto.Email
        };

        var addedProfile = await _userProfileRepository.AddUserProfileAsync(newProfile);

        return new UserProfileResponse
        {
            UserID = addedProfile.UserId,
            FirstName = addedProfile.FirstName,
            LastName = addedProfile.LastName,
            Phone = addedProfile.Phone,
            Birthday = addedProfile.Birthday,
            Gender = addedProfile.Gender,
            Email = addedProfile.Email
        };
    }

        public async Task<bool> UpdateUserProfileAsync(int userId, UserProfileResponse profileDto)
    {
        var profile = await _userProfileRepository.GetUserProfileAsync(userId); ;

        if (profile == null) return false;

        profile.FirstName = profileDto.FirstName;
        profile.LastName = profileDto.LastName;
        profile.Phone = profileDto.Phone;
        profile.Birthday = profileDto.Birthday;
        profile.Gender = profileDto.Gender;
        profile.Email = profileDto.Email;

        _userProfileRepository.UpdateUserProfileAsync(profile);

        return true;
    }

    Task<UserProfileResponse> IUserProfileService.GetUserProfileAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserProfileAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
