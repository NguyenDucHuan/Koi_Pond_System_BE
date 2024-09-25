using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly KpcosdbContext _context;

        public ServiceRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Service> AddServiceAsync(Service service)
        {
            var serviceadd = await _context.Services.AddAsync(service);
            if (serviceadd != null)
            {
                throw new Exception("Service have exist");
            }
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
            {
                throw new Exception("Service not found");
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task<Service> GetServiceAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
            {
                return null;
            }
            return service;
        }

        public async Task<List<Service>> GetServicesAsync()
        {
            var services = await _context.Services.ToListAsync();
            if (services == null)
            {
                return null;
            }
            return services;
        }


        public async Task<Service> UpdateServiceAsync(Service service)
        {
            var checkExist = await _context.Services.FindAsync(service.Id);
            if (checkExist == null)
            {
                throw new Exception("Service not found");
            }
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return service;
        }
    }
}
