using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetServicesAsync();
        Task<Service> GetServiceAsync(int serviceId);
        Task<Service> AddServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int serviceId);
    }
}
