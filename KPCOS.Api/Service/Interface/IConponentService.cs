using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Response.Componant;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IComponentService
    {
        Task<List<Component>> GetAllComponentAsync();
        Task<Component> AddComponentAsync(CreateComponentRequest component);
        Task DeleteComponentAsync(int componentId);
        Task<Component> GetComponentAsync(int componentId);
        Task<Component> UpdateComponentAsync(Component component);

        Task<GetComponentTypesResponse> GetComponentsAsync();
    }
}