using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.Api.Untils;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.Exceptions;

namespace KPCOS.Api.Service.Implement
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository _serviveTyperepo;
        private readonly IServiceRepository _servicerepo;

        public ServiceTypeService(IServiceRepository serviceRepository, IServiceTypeRepository serviceTypeRepository)
        {
            _servicerepo = serviceRepository;
            _serviveTyperepo = serviceTypeRepository;
        }
        public async Task<GetServiceTypesResponse> GetServiceTypesAsync()
        {
            try
            {
                var serviceTypes = await _serviveTyperepo.GetServiceTypesAsync();
                if (serviceTypes == null)
                {
                    throw new NotFoundException("serviceType List is empty");
                }
                var services = await _servicerepo.GetServicesAsync();
                if (serviceTypes == null)
                {
                    throw new NotFoundException("service List is empty");
                }
                var ServiceTypesResponses = serviceTypes.merServiceListToServiceTypeList(services);
                return ServiceTypesResponses;
            }
            catch (Exception ex)
            {
                string error = ErrorUtil.GetErrorString("Exception", ex.Message);
                throw new Exception(error);
            }
        }
    }
}