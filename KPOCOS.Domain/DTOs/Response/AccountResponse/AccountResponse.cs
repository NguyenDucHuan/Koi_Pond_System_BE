using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Account
{
    public class AccountResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string RoleName { get; set; }

        public string AccessToken { get; set; } // Thêm trường này

        public bool Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

}
