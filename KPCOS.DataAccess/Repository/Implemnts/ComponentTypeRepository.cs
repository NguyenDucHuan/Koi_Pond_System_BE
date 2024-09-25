using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        private readonly KpcosdbContext _context;

        public ComponentTypeRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<ComponentType> AddComponentTypeAsync(ComponentType componentType)
        {
            var componentTypeadd = await _context.ComponentTypes.AddAsync(componentType);
            if (componentTypeadd != null)
            {
                throw new Exception("ComponentType have exist");
            }
            _context.ComponentTypes.Add(componentType);
            await _context.SaveChangesAsync();
            return componentType;
        }

        public async Task DeleteComponentTypeAsync(int componentTypeId)
        {
            var componentType = await _context.ComponentTypes.FindAsync(componentTypeId);
            if (componentType == null)
            {
                throw new Exception("ComponentType not found");
            }
            _context.ComponentTypes.Remove(componentType);
            await _context.SaveChangesAsync();
        }

        public async Task<ComponentType> GetComponentTypeAsync(int componentTypeId)
        {
            var componentType = await _context.ComponentTypes.FindAsync(componentTypeId);
            if (componentType == null)
            {
                return null;
            }
            return componentType;
        }

        public async Task<List<ComponentType>> GetComponentTypesAsync()
        {
            var componentTypes = await _context.ComponentTypes.ToListAsync();
            if (componentTypes == null)
            {
                return null;
            }
            return componentTypes;
        }

        public async Task<ComponentType> UpdateComponentTypeAsync(ComponentType componentType)
        {
            var componentType1 = await _context.ComponentTypes.FindAsync(componentType.Id);
            if (componentType1 == null)
            {
                throw new Exception("ComponentType not found");
            }
            _context.ComponentTypes.Update(componentType);
            await _context.SaveChangesAsync();
            return componentType;
        }
    }
}