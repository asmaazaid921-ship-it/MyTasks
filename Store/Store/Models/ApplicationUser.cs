using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
            public string? Address { get; set; }
    }
}
