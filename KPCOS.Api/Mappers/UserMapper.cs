using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class UserMapper
    {
        public static UserProfile RegisToProfile(this UserProfile profile)
        {
            return new UserProfile
            {
                LastName = profile.LastName,
                FirstName = profile.FirstName,
                Phone = profile.Phone,
                Email = profile.Email,
                Birthday = profile.Birthday,
                Gender = profile.Gender,
                AccountId = 0
            };
        }
    }
}
