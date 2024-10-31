using Store.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.ServicesFolder.Tokens
{
    public interface ITokenServices
    {
        string GenerateToken(AppUser appUser);
    }
}
