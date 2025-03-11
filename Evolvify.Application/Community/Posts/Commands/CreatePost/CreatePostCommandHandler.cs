using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Posts.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System.Net;

namespace Evolvify.Application.Community.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ApiResponse<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _mapper = mapper;



        }
        public async Task<ApiResponse<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();

            if (user.Id == null)
            {
                throw new UnAuthourizeException("User not found");
            }


            var post = new Post
            {
                Content = request.Content,
                UserId = user.Id,
            };
            await _unitOfWork.Repository<Post, Guid>().CreateAsync(post);
            await _unitOfWork.CompleteAsync();

            var postDto = _mapper.Map<PostDto>(post);

            return new ApiResponse<PostDto>(postDto);

        }
    }
}
