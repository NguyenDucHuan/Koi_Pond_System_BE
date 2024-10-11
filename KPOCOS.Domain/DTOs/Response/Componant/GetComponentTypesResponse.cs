using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response.Componant
{
    public class GetComponentTypesResponse
    {
        public List<GetComponentsResponse> ComponentTypes { get; set; }
    }
}