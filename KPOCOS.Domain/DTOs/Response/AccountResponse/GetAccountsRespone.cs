using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetAccountsRespone
    {
        public List<GetAccountRespone> Accounts { get; set; }
    }
}