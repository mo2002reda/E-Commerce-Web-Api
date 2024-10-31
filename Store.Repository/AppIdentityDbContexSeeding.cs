using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.Identity;

namespace Store.Repository
{
    public class AppIdentityDbContexSeeding
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Mohamed Reda",
                    Email = "Mohamed@gmail.com",
                    address = new Address
                    {
                        FirstName = "Mohamed",
                        LastName = "Reda",
                        City = "Obour",
                        Street = "77",
                        ZipCode = "12543"

                    }

                };
                await userManager.CreateAsync(user, "password123!");
            }
        }

    }
}
