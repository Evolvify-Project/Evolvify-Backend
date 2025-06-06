﻿using Evolvify.Application.Common.User;
using Evolvify.Domain.Constants;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.CommunitySpecification;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Commands.UpdateComment
{
    public class UpdateCommentOnPostCommandHandler : IRequestHandler<UpdateCommentOnPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        public UpdateCommentOnPostCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _userContext = userContext;
          
            _unitOfWork = unitOfWork;
            
        }
        public async Task Handle(UpdateCommentOnPostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.PostId);
            var post = await _unitOfWork.Repository<Post, Guid>().GetByIdWithSpec(spec);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId.ToString());
            }

            var comment = post.Comments.FirstOrDefault(x => x.Id == request.CommentId);
            if (comment == null)
            {
                   throw new NotFoundException(nameof(Comment), request.CommentId.ToString());
            }

            var userId = _userContext.GetCurrentUser().Id;
            var role = _userContext.GetCurrentUser().Role;



            if (comment.UserId != userId && role !=UserRole.Admin)
            {
                throw new ForbiddenException("update", "comment");
            }
            
            
            comment.Content = request.Content;

            await _unitOfWork.CompleteAsync();


            
        }
    }
}
