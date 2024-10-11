using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetAccountRespone
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateOnly? Birthday { get; set; }

        public string Gender { get; set; }

        public string RoleName { get; set; }

        public bool Status { get; set; }


    }
}