using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Likes.OnPost
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public LikePostCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<ApiResponse<bool>> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {

            var user=_userContext.GetCurrentUser();
            

            var post= await _unitOfWork.Repository<Post,Guid>().GetByIdAsync(request.PostId);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId.ToString());
            }

            var like = post.Likes.FirstOrDefault(x => x.UserId == user.Id);

            if (like != null)
            {
                _unitOfWork.Repository<PostLike, Guid>().Delete(like);
                await _unitOfWork.CompleteAsync();

                return new ApiResponse<bool>(true, StatusCodes.Status200OK, "Post Unliked Successfully !!!");

            }
           
                var newLike = new PostLike
                {
                    PostId = post.Id,
                    UserId = user.Id
                };
                await _unitOfWork.Repository<PostLike, Guid>().CreateAsync(newLike);
                await _unitOfWork.CompleteAsync();

            

            return new ApiResponse<bool>(true, StatusCodes.Status200OK, "Post Liked Successfully !!!");

        }
    }
}
