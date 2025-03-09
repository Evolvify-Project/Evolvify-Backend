using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.DTOs.Response;
using MediatR;

namespace Evolvify.Application.Community.Comments.Commands.CreateComment
{
    public record AddCommentOnPostCommand(Guid PostId, string Content) : IRequest<ApiResponse<CommentDto>>;
    
}
