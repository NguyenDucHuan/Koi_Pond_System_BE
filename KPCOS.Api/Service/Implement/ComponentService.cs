using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Implemnts;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentService(IComponentRepository componentRepository)
        {
            _componentRepository = _componentRepository;
        }

        public async Task<Component> AddComponentAsync(Component component)
        {
            var check = await _componentRepository.AddComponentAsync(component);
            return component;
        }

        public async Task DeleteComponentAsync(int componentId)
        {
            await _componentRepository.DeleteComponentAsync(componentId);
        }

        public async Task<List<Component>> GetComponentsAsync()
        {
            return await _componentRepository.GetComponentsAsync();
        }

        public async Task<Component> UpdateComponentAsync(Component component)
        {
            return await _componentRepository.UpdateComponentAsync(component);
        }

        public async Task<Component> GetComponentAsync(int componentId)
        {
            var component = await _componentRepository.GetComponentAsync(componentId);
            if (component == null)
            {
                throw new ArgumentException("No component found");
            }
            return component;
        }

    }
}