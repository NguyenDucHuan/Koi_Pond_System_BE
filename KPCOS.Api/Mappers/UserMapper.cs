using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class UserMapper
    {
        public static UserProfile RegisToProfile(this RegisterUserProfile profile)
        {
            return new UserProfile
            {
                LastName = profile.LastName,
                FirstName = profile.FirstName,
                Phone = profile.Phone,
                Email = profile.Email,
                Birthday = profile.Birthday,
                Gender = profile.Gender
            };
        }
    }
}
