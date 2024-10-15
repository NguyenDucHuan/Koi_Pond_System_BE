using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class PondComponentRepository : IPondComponentRepository
    {
        private readonly KpcosdbContext _context;

        public PondComponentRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<PondComponent> AddPondComponentAsync(PondComponent pondComponent)
        {
            await _context.PondComponents.AddAsync(pondComponent);
            await _context.SaveChangesAsync();
            return pondComponent;
        }

        public async Task DeletePondComponentAsync(int pondComponentId)
        {
            var pondComponent = await _context.PondComponents.FindAsync(pondComponentId);
            if (pondComponent == null)
            {
                throw new Exception("PondComponent not found");
            }
            _context.PondComponents.Remove(pondComponent);
            await _context.SaveChangesAsync();
        }

        public async Task<PondComponent> GetPondComponentAsync(int pondComponentId)
        {
            return await _context.PondComponents.FindAsync(pondComponentId);
        }

        public async Task<List<PondComponent>> GetPondComponentByComponentIdAsync(int componentId)
        {
            return await _context.PondComponents.Where(pc => pc.ComponentId == componentId).ToListAsync();
        }

        public async Task<List<PondComponent>> GetPondComponentByPondIdAsync(int pondId)
        {
            return await _context.PondComponents.Where(pc => pc.PondId == pondId).ToListAsync();
        }

        public async Task<PondComponent> UpdatePondComponentAsync(PondComponent pondComponent)
        {
            var checkExist = await _context.PondComponents.FindAsync(pondComponent.PondId, pondComponent.ComponentId);
            if (checkExist == null)
            {
                throw new Exception("PondComponent not found");
            }
            _context.PondComponents.Update(pondComponent);
            await _context.SaveChangesAsync();
            return pondComponent;
        }
    }
}