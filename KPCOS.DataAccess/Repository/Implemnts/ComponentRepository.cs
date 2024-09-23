using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly KpcosdbContext _context;

        public ComponentRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<System.ComponentModel.Component> AddComponentAsync(System.ComponentModel.Component component)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComponentAsync(int componentId)
        {
            throw new NotImplementedException();
        }

        public Task<System.ComponentModel.Component> GetComponentAsync(int componentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<System.ComponentModel.Component>> GetComponentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<System.ComponentModel.Component> UpdateComponentAsync(System.ComponentModel.Component component)
        {
            throw new NotImplementedException();
        }
    }
}