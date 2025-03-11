using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Likes.OnPost
{
    public record LikePostCommand(Guid PostId) : IRequest<ApiResponse<bool>>;
    
}
