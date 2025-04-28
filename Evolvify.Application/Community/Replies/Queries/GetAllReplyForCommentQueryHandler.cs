using AutoMapper;
using Evolvify.Application.Community.Replies.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Specification.CommunitySpecification;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Replies.Queries
{
    public class GetAllReplyForCommentQueryHandler:IRequestHandler<GetAllReplyForCommentQuery, ApiResponse<IEnumerable<ReplyDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllReplyForCommentQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<ReplyDto>>> Handle(GetAllReplyForCommentQuery request, CancellationToken cancellationToken)
        {
            var spec=new CommentSpecification(request.CommentId);
            var comments = await _unitOfWork.Repository<Comment, Guid>().GetAllWithSpec(spec);

            var replies = comments.SelectMany(c => c.Replies);

            var replyDtos = _mapper.Map<IEnumerable<ReplyDto>>(replies);

            return new ApiResponse<IEnumerable<ReplyDto>>(replyDtos);
           
        }
    }
    
}
