using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Commands.UpdatePost
{
    public record UpdatePostCommand(Guid Id, string Content) : IRequest;
    
}
