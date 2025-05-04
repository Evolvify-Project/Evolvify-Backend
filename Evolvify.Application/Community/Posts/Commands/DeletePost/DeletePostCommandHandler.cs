using Evolvify.Application.Common.User;
using Evolvify.Domain.Constants;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.CommunitySpecification;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork,IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            
        }
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.Id);

            var post = await _unitOfWork.Repository<Post, Guid>().GetByIdWithSpec(spec);
            if (post == null)
            {
                throw new NotFoundException("Post Not Found");
            }

            var userId=_userContext.GetCurrentUser().Id;
            var role = _userContext.GetCurrentUser().Role;
            if (post.UserId != userId && role !=UserRole.Admin)
            {
                throw new ForbiddenException("delete", "post");
            }
            

            _unitOfWork.Repository<Comment, Guid>().DeleteRange(post.Comments);
            _unitOfWork.Repository<PostLike, Guid>().DeleteRange(post.Likes);
            _unitOfWork.Repository<Post, Guid>().Delete(post);


            await _unitOfWork.CompleteAsync();
    
        }
    }
}
