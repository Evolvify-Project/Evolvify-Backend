using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.Community.Comments.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.Community.Comments.Commands.CreateComment;

public class AddCommentOnPostCommandHandler : IRequestHandler<AddCommentOnPostCommand, ApiResponse<CommentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;
    public AddCommentOnPostCommandHandler(IUnitOfWork unitOfWork,IUserContext userContext, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _mapper = mapper;
        
    }
    public async Task<ApiResponse<CommentDto>> Handle(AddCommentOnPostCommand request, CancellationToken cancellationToken)
    {
        var user=_userContext.GetCurrentUser();
        if(user == null)
        {
            throw new UnauthorizedAccessException("User not found");
        }

        var userId = user.Id;
       
        var post = _unitOfWork.Repository<Post,Guid>().GetByIdAsync(request.PostId);

        if(post == null)
        {
            throw new NotFoundException("Post not found");
        }
        var comment = new Comment
        {
            Content = request.Content,
            PostId = request.PostId,
            UserId = userId
        };

          await  _unitOfWork.Repository<Comment,Guid>().CreateAsync(comment);

         await _unitOfWork.CompleteAsync();

        var commentDto = _mapper.Map<CommentDto>(comment);

        return new ApiResponse<CommentDto>(commentDto);
        

    }
}
