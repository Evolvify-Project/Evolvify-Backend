using AutoMapper;
using Evolvify.Application.Community.Posts.DTOs;
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

namespace Evolvify.Application.Community.Posts.Queries.GetPostQuery
{
    public record GetPostQuery(Guid Id): IRequest<ApiResponse<PostDto>>;
    
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, ApiResponse<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPostQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PostDto>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post,Guid>().GetByIdAsync(request.Id);
            
            if(post == null)
            {
                throw new NotFoundException("Post not found");
            }

            var postDto = _mapper.Map<PostDto>(post);

            return new ApiResponse<PostDto>(postDto);



        }
    }
}
