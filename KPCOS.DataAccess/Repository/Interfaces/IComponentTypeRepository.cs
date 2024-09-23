using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IComponentTypeRepository
    {
        Task<List<ComponentType>> GetComponentTypesAsync();
        Task<ComponentType> GetComponentTypeAsync(int componentTypeId);
        Task<ComponentType> AddComponentTypeAsync(ComponentType componentType);
        Task<ComponentType> UpdateComponentTypeAsync(ComponentType componentType);
        Task DeleteComponentTypeAsync(int componentTypeId);
    }
}