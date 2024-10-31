using Store.Services.ServicesFolder.UseServices.DTOS;

namespace Store.Services.ServicesFolder.UseServices
{
    public interface IUserServices
    {
        Task<UserDTO> Register(RegisterDTO input);
        Task<UserDTO> Login(LoginDTO input);
    }
}
