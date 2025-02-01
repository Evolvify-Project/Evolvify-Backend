using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Token;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Login
{
    public class LoginCommand:IRequest<ApiResponse<TokenResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
