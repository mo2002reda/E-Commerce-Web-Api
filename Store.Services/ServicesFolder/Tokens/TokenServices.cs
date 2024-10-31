using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Services.ServicesFolder.Tokens
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configration;//to can initialize json.appSitting

        private readonly SymmetricSecurityKey _key;//to can libs which encode the key

        public TokenServices(IConfiguration configration)
        {
            _configration = configration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Token:Key"]));//encode token
        }

        public string GenerateToken(AppUser appUser)
        {
            var Claims = new List<Claim>//Will be payload Data
            {
                new Claim(ClaimTypes.Email,appUser.Email),
                new Claim(ClaimTypes.GivenName,appUser.DisplayName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);//will be Credentials

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Issuer = _configration["Token:Issuer"],
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
