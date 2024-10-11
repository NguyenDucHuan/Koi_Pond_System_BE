using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetServiceTypeResponse
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = null!;

        public List<GetServiceResponse> ServiceResponses { get; set; } = new List<GetServiceResponse>();

    }

}