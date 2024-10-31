using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.Identity;
using Store.Services.HandleResponse;
using Store.Services.ServicesFolder.UseServices;
using Store.Services.ServicesFolder.UseServices.DTOS;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO input)
        {
            var user = await _userServices.Login(input);
            if (user == null)
            {
                return Unauthorized(new CustomeException(401));
            }
            return Ok(user);
        }
    }
}
