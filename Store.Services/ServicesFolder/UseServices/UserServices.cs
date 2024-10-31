using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.Identity;
using Store.Services.ServicesFolder.Tokens;
using Store.Services.ServicesFolder.UseServices.DTOS;

namespace Store.Services.ServicesFolder.UseServices
{
    public class UserServices : IUserServices
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;

        public UserServices(SignInManager<AppUser> signInManager,
                            UserManager<AppUser> userManager,
                            ITokenServices tokenServices
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenServices = tokenServices;
        }

        public async Task<UserDTO> Login(LoginDTO input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            //false : not block user if he entered wrong password many time
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to login {input.Email}");
            }

            return new UserDTO
            {
                Email = input.Email,
                DisplayName = user.DisplayName,
                Token = _tokenServices.GenerateToken(user)
            };

        }

        public Task<UserDTO> Register(RegisterDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
