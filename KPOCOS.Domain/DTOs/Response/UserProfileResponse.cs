using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class UserProfileResponse
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateOnly? Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
    }
}
