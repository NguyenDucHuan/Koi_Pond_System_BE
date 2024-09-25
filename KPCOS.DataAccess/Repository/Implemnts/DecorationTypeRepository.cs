using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DecorationTypeRepository : IDecorationTypeRepository
    {
        private readonly KpcosdbContext _context;

        public DecorationTypeRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<DecorationType> AddDecorationTypeAsync(DecorationType decorationType)
        {
            var decorationTypeadd = await _context.DecorationTypes.AddAsync(decorationType);
            if (decorationTypeadd != null)
            {
                throw new Exception("DecorationType have exist");
            }
            _context.DecorationTypes.Add(decorationType);
            await _context.SaveChangesAsync();
            return decorationType;
        }

        public async Task DeleteDecorationTypeAsync(int decorationTypeId)
        {
            var decorationType = await _context.DecorationTypes.FindAsync(decorationTypeId);
            if (decorationType == null)
            {
                throw new Exception("DecorationType not found");
            }
            _context.DecorationTypes.Remove(decorationType);
            await _context.SaveChangesAsync();
        }

        public async Task<DecorationType> GetDecorationTypeAsync(int decorationTypeId)
        {
            var decorationType = await _context.DecorationTypes.FindAsync(decorationTypeId);
            if (decorationType == null)
            {
                return null;
            }
            return decorationType;
        }

        public async Task<List<DecorationType>> GetDecorationTypesAsync()
        {
            var decorationTypes = await _context.DecorationTypes.ToListAsync();
            if (decorationTypes == null)
            {
                return null;
            }
            return decorationTypes;
        }

        public async Task<DecorationType> UpdateDecorationTypeAsync(DecorationType decorationType)
        {
            var decorationType1 = await _context.DecorationTypes.FindAsync(decorationType.Id);
            if (decorationType1 == null)
            {
                throw new Exception("DecorationType not found");
            }
            _context.DecorationTypes.Update(decorationType);
            await _context.SaveChangesAsync();
            return decorationType;
        }
    }
}