using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest
    {
        public IFormFile? Image { get; set; }
    }
    
}
