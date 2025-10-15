using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace practice_12_october.Models
{
    public class Register : IdentityUser
    {
        public string? Name {  get; set; }
        public string? Address { get; set; }
    }
}
