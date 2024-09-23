using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<List<ServiceType>> GetServiceTypesAsync();
        Task<ServiceType> GetServiceTypeAsync(int serviceTypeId);
        Task<ServiceType> AddServiceTypeAsync(ServiceType serviceType);
        Task<ServiceType> UpdateServiceTypeAsync(ServiceType serviceType);
        Task DeleteServiceTypeAsync(int serviceTypeId);
    }
}