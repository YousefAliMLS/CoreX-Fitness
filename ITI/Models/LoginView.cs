using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace ITI.Models
{
    public class LoginView
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display( Name = "Remember me? ")]
        public bool rememberMe { get; set; }
    }
}
