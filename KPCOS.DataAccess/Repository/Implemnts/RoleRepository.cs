using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class RoleRepository : IRoleRepository
    {
        private readonly KpcosdbContext _context;

        public RoleRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            var roleadd = await _context.Roles.AddAsync(role);
            if (roleadd != null)
            {
                throw new Exception("Role have exist");
            }
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            if (roles == null)
            {
                return null;
            }
            return roles;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            var checkExist = await _context.Roles.FindAsync(role.Id);
            if (checkExist == null)
            {
                throw new Exception("Role not found");
            }
            _context.Update(role);
            return role;
        }
    }
}