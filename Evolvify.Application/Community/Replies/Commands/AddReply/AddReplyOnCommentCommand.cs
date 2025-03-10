using Evolvify.Application.Community.Comments.Commands.CreateComment;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Replies.Commands.AddReply
{
    public record AddReplyOnCommentCommand(Guid CommentId, string Content) : IRequest<ApiResponse<ReplyDto>>;
   
}
