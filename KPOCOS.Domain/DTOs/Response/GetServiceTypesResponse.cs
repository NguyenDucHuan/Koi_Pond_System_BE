using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetServiceTypesResponse
    {
        public List<GetServiceTypeResponse> ServiceTypesResponses { get; set; } = new List<GetServiceTypeResponse>();
    }
}