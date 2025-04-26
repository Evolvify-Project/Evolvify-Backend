using AutoMapper;
using Evolvify.Application.Community.Posts.DTOs;
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

namespace Evolvify.Application.Community.Posts.Queries.GetAllPosts
{
    public record GetAllPostsQuery : IRequest<ApiResponse<IEnumerable<PostDto>>>;
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery,ApiResponse<IEnumerable<PostDto>>>
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public GetAllPostsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification();
            var posts=await _unitOfWork.Repository<Post, Guid>().GetAllWithSpec(spec);
            

            if (posts == null)
            {
                throw new NotFoundException("Posts not found");
            }
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
           
                       
            return new ApiResponse<IEnumerable<PostDto>>(postDtos);


            
        }
    }
}
