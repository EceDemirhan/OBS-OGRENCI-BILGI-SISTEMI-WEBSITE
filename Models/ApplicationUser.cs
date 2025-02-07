using Microsoft.AspNetCore.Identity;

namespace WebApplication21.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}
