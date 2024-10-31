using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store.Data.DataContext;
using Store.Data.Entities.Identity;
using System.Text;

namespace Store.Api.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration _configration)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);//to can call [AddEntityFrameworkStores & AddSignInManager]
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();//will add user into database
            builder.AddSignInManager<SignInManager<AppUser>>();//Responsiple for sign in data which user will entered later
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Token:Key"])),
                            ValidateIssuer = true,
                            ValidIssuer = _configration["Token:Issuer"],
                            ValidateAudience = false
                        };

                    });



            return services;
        }
    }
}
