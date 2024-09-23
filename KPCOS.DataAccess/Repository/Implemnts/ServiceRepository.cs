﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly KpcosdbContext _context;

        public ServiceRepository(KpcosdbContext context)
        {
            _context = context;
        }

        public Task<Service> AddServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceAsync(int serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetServiceAsync(int serviceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetServicesAsync()
        {
            throw new NotImplementedException();
        }


        public Task<Service> UpdateServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public T SaveChange<T>(T u)
        {
            _context.SaveChanges();
            return u;
        }
    }
}
