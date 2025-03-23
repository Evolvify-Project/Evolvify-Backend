using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.CommunitySpecification;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Likes.OnComment
{
    public class LikeCommentCommandHandler : IRequestHandler<LikeCommentCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public LikeCommentCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }
        public async Task<ApiResponse<bool>> Handle(LikeCommentCommand request, CancellationToken cancellationToken)
        {
            var spec = new CommentSpecification(request.CommentId);

           var comment = await _unitOfWork.Repository<Comment, Guid>().GetByIdWithSpec(spec);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Comment), request.CommentId.ToString());
            }
            var user = _userContext.GetCurrentUser();
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var like = comment.Likes.FirstOrDefault(x => x.UserId == user.Id);
            if (like != null)
            {
                _unitOfWork.Repository<CommentLike, Guid>().Delete(like);
                await _unitOfWork.CompleteAsync();
                return new ApiResponse<bool>(true, StatusCodes.Status200OK, "Comment Unliked Successfully !!!");
            }
            var newLike = new CommentLike
            {
                CommentId = comment.Id,
                UserId = user.Id
            };
            await _unitOfWork.Repository<CommentLike, Guid>().CreateAsync(newLike);
            await _unitOfWork.CompleteAsync();
            return new ApiResponse<bool>(true, StatusCodes.Status200OK, "Comment Liked Successfully !!!");
        }
    }
}
