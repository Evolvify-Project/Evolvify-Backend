using AutoMapper;
using Evolvify.Application.Community.Comments.DTOs;
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

namespace Evolvify.Application.Community.Comments.Queries.GetAllCommentForPost
{
    public class GetAllCommentForPostQueryHandler : IRequestHandler<GetAllCommentForPostQuery, ApiResponse<IEnumerable<CommentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCommentForPostQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            
        }

        public async Task<ApiResponse<IEnumerable<CommentDto>>> Handle(GetAllCommentForPostQuery request, CancellationToken cancellationToken)
        {

            var spec = new PostSpecification(request.PostId);
            var post = await _unitOfWork.Repository<Post, Guid>().GetByIdWithSpec(spec);
            if (post == null)
            {
                throw new NotFoundException(nameof(Post),request.PostId.ToString());
            }

            var mainComments = post.Comments.Where(c => c.ParentCommentId == null).ToList();

            if (mainComments.Any())
            {
                var comments=_mapper.Map<IEnumerable<CommentDto>>(mainComments);
                return new ApiResponse<IEnumerable<CommentDto>>(comments);
            }

            throw new NotFoundException("Comments not found");


            
        }
    }
}
