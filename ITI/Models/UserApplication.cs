using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace ITI.Models
{
    public class UserApplication : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
        public DateTime creationDate { get; set; } = DateTime.Now;
    }
}
