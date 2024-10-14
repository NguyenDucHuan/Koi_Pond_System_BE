using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetUserProfileResponse
    {
        public GetAccountRespone account { get; set; } = new GetAccountRespone();
        public GetPondsResponse ponds { get; set; } = new GetPondsResponse();

        public GetOrdersResponse orders { get; set; } = new GetOrdersResponse();
    }
}