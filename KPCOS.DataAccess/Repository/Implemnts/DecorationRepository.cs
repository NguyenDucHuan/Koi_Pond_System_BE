using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class DecorationRepository : IDecorationRepository
    {
        private readonly KpcosdbContext _context;

        public DecorationRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<Decoration> AddDecorationAsync(Decoration decoration)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDecorationAsync(int decorationId)
        {
            throw new NotImplementedException();
        }

        public Task<Decoration> GetDecorationAsync(int decorationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Decoration>> GetDecorationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Decoration> UpdateDecorationAsync(Decoration decoration)
        {
            throw new NotImplementedException();
        }
    }
}