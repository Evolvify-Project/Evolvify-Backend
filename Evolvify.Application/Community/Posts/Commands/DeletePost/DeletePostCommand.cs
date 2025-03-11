using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Commands.DeletePost
{
    public record DeletePostCommand (Guid Id):IRequest;
    
   
}
