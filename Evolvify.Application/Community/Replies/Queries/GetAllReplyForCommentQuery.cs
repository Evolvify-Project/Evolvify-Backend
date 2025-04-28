using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Replies.Queries
{
    public class GetAllReplyForCommentQuery:IRequest<ApiResponse<IEnumerable<ReplyDto>>>
    {
        public Guid CommentId { get; set; } 
        public GetAllReplyForCommentQuery(Guid commentId)
        {
            CommentId = commentId;
        }
    }
   
}
