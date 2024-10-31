using Microsoft.AspNetCore.Identity;

namespace Store.Data.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address address { get; set; }
    }
}
