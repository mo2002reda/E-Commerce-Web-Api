using System.ComponentModel.DataAnnotations;

namespace Store.Services.ServicesFolder.UseServices.DTOS
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
