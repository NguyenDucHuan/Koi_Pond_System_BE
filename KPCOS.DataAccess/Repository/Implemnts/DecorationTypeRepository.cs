using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DecorationTypeRepository : IDecorationTypeRepository
    {
        private readonly KpcosdbContext _context;

        public DecorationTypeRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<DecorationType> AddDecorationTypeAsync(DecorationType decorationType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDecorationTypeAsync(int decorationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<DecorationType> GetDecorationTypeAsync(int decorationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DecorationType>> GetDecorationTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DecorationType> UpdateDecorationTypeAsync(DecorationType decorationType)
        {
            throw new NotImplementedException();
        }
    }
}