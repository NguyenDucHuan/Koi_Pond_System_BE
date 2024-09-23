using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly KpcosdbContext _context;

        public ServiceTypeRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<ServiceType> AddServiceTypeAsync(ServiceType serviceType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceTypeAsync(int serviceTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceType> GetServiceTypeAsync(int serviceTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceType>> GetServiceTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceType> UpdateServiceTypeAsync(ServiceType serviceType)
        {
            throw new NotImplementedException();
        }
    }
}