using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Response.Componant;
using KPOCOS.Domain.Exceptions;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IComponentTypeRepository _componentTypeRepository;

        public ComponentService(IComponentRepository componentRepository, IComponentTypeRepository componentTypeRepository)
        {
            _componentRepository = componentRepository;
            _componentTypeRepository = componentTypeRepository;
        }

        public async Task<Component> AddComponentAsync(Component component)
        {
            return await _componentRepository.AddComponentAsync(component);
        }

        public Task DeleteComponentAsync(int componentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Component>> GetAllComponentAsync()
        {
            return await _componentRepository.GetComponentsAsync();
        }

        public async Task<Component> GetComponentAsync(int componentId)
        {
            return await _componentRepository.GetComponentAsync(componentId);
        }

        public async Task<GetComponentTypesResponse> GetComponentsAsync()
        {
            try
            {
                var components = await _componentRepository.GetComponentsAsync();
                if (components == null)
                {
                    throw new NotFoundException("Components not found");
                }
                var componentTypes = await _componentTypeRepository.GetComponentTypesAsync();
                if (componentTypes == null)
                {
                    throw new NotFoundException("Component types not found");
                }
                return componentTypes.MapToGetComponentsResponse(components);
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }

        public async Task<Component> UpdateComponentAsync(Component component)
        {
            return await _componentRepository.UpdateComponentAsync(component);
        }
    }
}