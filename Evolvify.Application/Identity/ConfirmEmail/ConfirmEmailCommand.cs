using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ConfirmEmail
{
  
    public class ConfirmEmailCommand : IRequest<ApiResponse<bool>>
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
