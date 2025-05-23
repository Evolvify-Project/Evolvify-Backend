using Evolvify.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> CreateToken(ApplicationUser user,UserManager<ApplicationUser> userManager);
    }
}
