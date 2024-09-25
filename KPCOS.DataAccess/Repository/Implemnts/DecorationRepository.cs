using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DecorationRepository : IDecorationRepository
    {
        private readonly KpcosdbContext _context;

        public DecorationRepository(KpcosdbContext context)
        {

        }

        public async Task<Decoration> AddDecorationAsync(Decoration decoration)
        {
            var decorationadd = await _context.Decorations.AddAsync(decoration);
            if (decorationadd != null)
            {
                throw new Exception("Decoration have exist");
            }
            _context.Decorations.Add(decoration);
            await _context.SaveChangesAsync();
            return decoration;
        }

        public async Task DeleteDecorationAsync(int decorationId)
        {
            var decoration = await _context.Decorations.FindAsync(decorationId);
            if (decoration == null)
            {
                throw new Exception("Decoration not found");
            }
            _context.Decorations.Remove(decoration);
            await _context.SaveChangesAsync();
        }

        public async Task<Decoration> GetDecorationAsync(int decorationId)
        {
            var decoration = await _context.Decorations.FindAsync(decorationId);
            if (decoration == null)
            {
                return null;
            }
            return decoration;
        }

        public async Task<List<Decoration>> GetDecorationsAsync()
        {
            var decorations = await _context.Decorations.ToListAsync();
            if (decorations == null)
            {
                return null;
            }
            return decorations;
        }

        public async Task<Decoration> UpdateDecorationAsync(Decoration decoration)
        {
            var decoration1 = await _context.Decorations.FindAsync(decoration.Id);
            if (decoration1 == null)
            {
                throw new Exception("Decoration not found");
            }
            _context.Decorations.Update(decoration);
            await _context.SaveChangesAsync();
            return decoration;
        }
    }
}