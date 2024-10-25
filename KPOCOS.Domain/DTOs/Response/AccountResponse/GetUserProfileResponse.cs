using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetUserProfileResponse
    {
        public GetAccountRespone account { get; set; } = new GetAccountRespone();
        public List<GetPondResponse> ponds { get; set; } = new List<GetPondResponse>();
        public List<GetOrderDetailResponse> orders { get; set; } = new List<GetOrderDetailResponse>();
    }
}