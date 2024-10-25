using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class PondRepository : IPondRepository
    {
        private readonly KpcosdbContext _context;

        public PondRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Pond> AddPondAsync(Pond pond)
        {
            _context.Ponds.Add(pond);
            await _context.SaveChangesAsync();
            return pond;
        }

        public async Task DeletePondAsync(int pondId)
        {
            var pond = await _context.Ponds.FindAsync(pondId);
            if (pond == null)
            {
                throw new Exception("Pond not found");
            }
            _context.Ponds.Remove(pond);
            await _context.SaveChangesAsync();
        }

        public async Task<Pond> GetPondAsync(int pondId)
        {
            var pond = await _context.Ponds.Include(p => p.PondComponents).FirstOrDefaultAsync(p => p.Id == pondId);
            if (pond == null)
            {
                return null;
            }
            return pond;
        }

        public async Task<List<Pond>> GetPondsByAccountIdAsync(int accountId)
        {
            var ponds = await _context.Ponds.Include(p => p.PondComponents).Where(p => p.AccountId == accountId).ToListAsync();
            if (ponds == null)
            {
                return null;
            }
            return ponds;
        }

        public async Task<List<Pond>> GetPondsAsync()
        {
            var ponds = await _context.Ponds.Include(p => p.PondComponents).ToListAsync();
            if (ponds == null)
            {
                return null;
            }
            return ponds;
        }

        public async Task UpdatePondAsync(Pond pond)
        {
            var pond1 = await _context.Ponds.FindAsync(pond.Id);
            if (pond1 == null)
            {
                throw new Exception("Pond not found");
            }
            _context.Ponds.Update(pond);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePondComponentsAsync(int pondId, List<UpdatePondComponentRequest> updatedComponents)
        {
            var currentComponentIds = updatedComponents.Select(c => c.componentId).ToList();
            await _context.PondComponents
                .Where(pc => pc.PondId == pondId && !currentComponentIds.Contains(pc.ComponentId))
                .ExecuteDeleteAsync();
            foreach (var component in updatedComponents)
            {
                await _context.PondComponents
                    .Where(pc => pc.PondId == pondId && pc.ComponentId == component.componentId)
                    .ExecuteUpdateAsync(pc => pc.SetProperty(p => p.Amount, p => component.amount));
            }
            var existingComponentIds = await _context.PondComponents.Where(pc => pc.PondId == pondId).Select(pc => pc.ComponentId).ToListAsync();
            var newComponents = updatedComponents.Where(c => !existingComponentIds.Contains(c.componentId)).Select(c => new PondComponent
            {
                PondId = pondId,
                ComponentId = c.componentId,
                Amount = c.amount
            })
    .ToList();
            if (newComponents.Any())
            {
                await _context.PondComponents.AddRangeAsync(newComponents);
            }
            await _context.SaveChangesAsync();
        }

    }
}