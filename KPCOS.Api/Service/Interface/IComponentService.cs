using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IComponentService
    {
        Task<Component> GetComponentAsync(int componentId);
        Task<List<Component>> GetComponentsAsync();

        Task<Component> AddComponentAsync(Component component);
        Task<Component> UpdateComponentAsync(Component component);
        Task DeleteComponentAsync(int componentId);
    }
}