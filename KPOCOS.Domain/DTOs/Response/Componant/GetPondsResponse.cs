using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetPondsResponse
    {
        public List<GetPondResponse> ponds { get; set; } = new List<GetPondResponse>();
    }
}