using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
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

            var comment = await _unitOfWork.Repository<Comment, Guid>().GetByIdAsync(request.CommentId);

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

            var replyDto=_mapper.Map<ReplyDto>(reply);
            return new ApiResponse<ReplyDto>(replyDto);
        }
    }
}
