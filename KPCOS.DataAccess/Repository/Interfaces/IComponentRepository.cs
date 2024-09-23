using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IComponentRepository
    {
        Task<List<Component>> GetComponentsAsync();
        Task<Component> GetComponentAsync(int componentId);
        Task<Component> AddComponentAsync(Component component);
        Task<Component> UpdateComponentAsync(Component component);
        Task DeleteComponentAsync(int componentId);
    }
}
