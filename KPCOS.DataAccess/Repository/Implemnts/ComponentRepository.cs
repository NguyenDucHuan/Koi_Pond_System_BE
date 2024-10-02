using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly KpcosdbContext _context;

        public ComponentRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Component> AddComponentAsync(Component component)
        {
            var componentadd = await _context.Components.FirstOrDefaultAsync(e => e.Name == component.Name);
            if (componentadd != null)
            {
                throw new Exception("Component have exist");
            }
            _context.Components.Add(component);
            await _context.SaveChangesAsync();
            return component;
        }

        public async Task DeleteComponentAsync(int componentId)
        {
            var component = await _context.Components.FindAsync(componentId);
            if (component == null)
            {
                throw new Exception("Component not found");
            }
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
        }

        public async Task<Component> GetComponentAsync(int componentId)
        {
            var component = await _context.Components.FindAsync(componentId);
            if (component == null)
            {
                return null;
            }
            return component;
        }

        public async Task<List<Component>> GetComponentsAsync()
        {
            var components = await _context.Components.ToListAsync();
            if (components == null)
            {
                return null;
            }
            return components;
        }

        public async Task<Component> UpdateComponentAsync(Component component)
        {
            var component1 = await _context.Components.FindAsync(component.Id);
            if (component == null)
            {
                throw new Exception("Component not found");
            }
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return component;
        }
    }
}