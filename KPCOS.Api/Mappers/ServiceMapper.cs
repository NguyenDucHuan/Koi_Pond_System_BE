using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class ServiceMapper
    {
        public static GetServiceTypesResponse merServiceListToServiceTypeList(this List<ServiceType> serviceType, List<KPOCOS.Domain.Models.Service> services)
        {
            // Create a new response object
            var response = new GetServiceTypesResponse
            {
                // Map the service types to the response
                ServiceTypesResponses = serviceType.Select(st => new GetServiceTypeResponse
                {
                    Id = st.Id,
                    TypeName = st.TypeName,
                    ServiceResponses = services.ToServiceResponse(st.Id)
                }).ToList()
            };

            return response;
        }

        public static List<GetServiceResponse> ToServiceResponse(this List<KPOCOS.Domain.Models.Service> services, int id)
        {
            return services.Where(s => s.ServiceTypeId == id).ToList().Select(service => new GetServiceResponse
            {
                Id = service.Id,
                Decription = service.Decription,
                Name = service.Name,
                PricePerM2 = service.PricePerM2
            }).ToList();
        }
    }
}