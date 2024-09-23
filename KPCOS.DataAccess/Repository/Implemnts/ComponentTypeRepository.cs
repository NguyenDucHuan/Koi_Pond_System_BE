using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        private readonly KpcosdbContext _context;

        public ComponentTypeRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<ComponentType> AddComponentTypeAsync(ComponentType componentType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComponentTypeAsync(int componentTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<ComponentType> GetComponentTypeAsync(int componentTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ComponentType>> GetComponentTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ComponentType> UpdateComponentTypeAsync(ComponentType componentType)
        {
            throw new NotImplementedException();
        }
    }
}