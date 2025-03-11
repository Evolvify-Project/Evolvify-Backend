using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Queries.GetAllCommentForPost
{
    public record GetAllCommentForPostQuery(Guid PostId):IRequest<ApiResponse<IEnumerable<CommentDto>>>;


}
