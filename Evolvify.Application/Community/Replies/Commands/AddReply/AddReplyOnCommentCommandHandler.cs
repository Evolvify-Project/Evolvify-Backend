using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Application.DTOs.Response;
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

namespace Evolvify.Application.Community.Replies.Commands.AddReply
{
    public class AddReplyOnCommentCommandHandler : IRequestHandler<AddReplyOnCommentCommand, ApiResponse<ReplyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        
        public AddReplyOnCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userContext = userContext;
            
        }
        public async Task<ApiResponse<ReplyDto>> Handle(AddReplyOnCommentCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            if(user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            var spec = new CommentSpecification(request.CommentId);

            var comment = await _unitOfWork.Repository<Comment, Guid>().GetByIdWithSpec(spec);

            if(comment == null)
            {
               throw new NotFoundException(nameof(Comment), request.CommentId.ToString());
            }

           

            var reply = new Comment
            {
                ParentCommentId = request.CommentId,
                Content = request.Content,
                PostId = comment.PostId,
                UserId = user.Id
            };

            await _unitOfWork.Repository<Comment, Guid>().CreateAsync(reply);
            await _unitOfWork.CompleteAsync();

            // Fetch the reply with includes
            var replySpec = new CommentSpecification(reply.Id);
            var replyWithIncludes = await _unitOfWork.Repository<Comment, Guid>().GetByIdWithSpec(replySpec);
            
            var replyDto = _mapper.Map<ReplyDto>(replyWithIncludes);

            return new ApiResponse<ReplyDto>(replyDto);
        }
    }
}
