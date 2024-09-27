using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly KpcosdbContext _context;

        public UserProfileRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> AddUserProfileAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
            Console.WriteLine(".........................232131.................................................................");
            return userProfile;
        }

        public async Task<UserProfile> CheckEmail(string email)
        {
            var check = await _context.UserProfiles.Include(e => e.Account).FirstOrDefaultAsync(e => e.Email == email);
            if (check == null)
            {
                return null;
            }
            return check;
        }

        public async Task DeleteUserProfileAsync(int userProfileId)
        {
            var userProfile = await _context.UserProfiles.FindAsync(userProfileId);
            if (userProfile == null)
            {
                throw new Exception("UserProfile not found");
            }
            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> GetUserProfileAsync(int userProfileId)
        {
            var userProfile = await _context.UserProfiles.Include(e => e.Account).FirstOrDefaultAsync(e => e.UserId == userProfileId);
            if (userProfile == null)
            {
                return null;
            }
            return userProfile;
        }

        public async Task<List<UserProfile>> GetUserProfilesAsync()
        {
            var userProfiles = await _context.UserProfiles.Include(e => e.Account).ToListAsync();
            if (userProfiles == null)
            {
                return null;
            }
            return userProfiles;
        }

        public async Task<UserProfile> UpdateUserProfileAsync(UserProfile userProfile)
        {
            var UserProfile = await _context.UserProfiles.Include(e => e.Account).FirstOrDefaultAsync(e => e.UserId == userProfile.UserId);
            if (UserProfile == null)
            {
                throw new Exception("UserProfile not found");
            }
            _context.Update(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }
    }
}