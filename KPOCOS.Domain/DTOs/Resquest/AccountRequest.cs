using KPOCOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class AccountRequest
    {
    }
    public class LoginResquest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto
    {
        public RegisterAccount registerAccount { get; set; } = new RegisterAccount();
        public RegisterUserProfile registerUserProfile { get; set; } = new RegisterUserProfile();
    }
    public class RegisterAccount
    {
        [Required(ErrorMessage = "Username is missing")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is missing")]
        public string Password { get; set; } = string.Empty;

    }
}
