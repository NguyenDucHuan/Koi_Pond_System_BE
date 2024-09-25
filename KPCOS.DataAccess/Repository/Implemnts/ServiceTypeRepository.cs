using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteServiceTypeAsync(int serviceTypeId)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(serviceTypeId);
            if (serviceType == null)
            {
                throw new Exception("ServiceType not found");
            }
            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceType> GetServiceTypeAsync(int serviceTypeId)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(serviceTypeId);
            if (serviceType == null)
            {
                return null;
            }
            return serviceType;
        }

        public async Task<List<ServiceType>> GetServiceTypesAsync()
        {
            var serviceTypes = await _context.ServiceTypes.ToListAsync();
            if (serviceTypes == null)
            {
                return null;
            }
            return serviceTypes;
        }

        public async Task<ServiceType> UpdateServiceTypeAsync(ServiceType serviceType)
        {
            var checkExist = await _context.ServiceTypes.FindAsync(serviceType.Id);
            if (checkExist == null)
            {
                throw new Exception("ServiceType not found");
            }
            _context.ServiceTypes.Update(serviceType);
            await _context.SaveChangesAsync();
            return serviceType;
        }
    }
}