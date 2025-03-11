using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Likes.OnComment
{
    public record LikeCommentCommand(Guid CommentId) : IRequest<ApiResponse<bool>>;
    
   
}
