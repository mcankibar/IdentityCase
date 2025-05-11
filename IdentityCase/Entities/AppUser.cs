using Microsoft.AspNetCore.Identity;

namespace IdentityCase.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? City { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
