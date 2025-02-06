using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ForgetPassword
{
    public class ForgetPasswordCommand:IRequest<ApiResponse<bool>>
    {
        public string Email { get; set; }=string.Empty;
    }
}
