using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetComponentsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<GetComponentResponse> Components { get; set; }
    }
}