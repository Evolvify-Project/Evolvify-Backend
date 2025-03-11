using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Commands.UpdateComment
{
    public record UpdateCommentOnPostCommand(Guid PostId, Guid CommentId, string Content) : IRequest;

}
