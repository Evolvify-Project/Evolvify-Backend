using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Commands.DeleteComment
{
    public record DeleteCommentOnPostCommand(Guid PostId ,Guid CommentId) : IRequest;
   
}
