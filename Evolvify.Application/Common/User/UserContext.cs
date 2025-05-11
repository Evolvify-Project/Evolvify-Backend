using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Common.User
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor )
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser GetCurrentUser()
        {

            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null || !user.Identity?.IsAuthenticated == true)
            {
                return null;
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            
            var UserName = user.FindFirst(ClaimTypes.Name)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var roles = user.FindFirst(ClaimTypes.Role)?.Value;
            
            return new CurrentUser(userId, UserName, email, roles);
                
        }
        
    }
}

