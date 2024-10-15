using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.DTOs.Response;

namespace KPCOS.Api.Service.Interface
{
    public interface IServiceTypeService
    {
        Task<GetServiceTypesResponse> GetServiceTypesAsync();

    }
}