using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class UserProfileRequest
    {
    }
    public class RegisterUserProfile
    {
        [Required(ErrorMessage = "Lastname is missing")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "First is missing")]
        public string FirstName { get; set; } = null!;
        public string? Phone { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }

    }
}
