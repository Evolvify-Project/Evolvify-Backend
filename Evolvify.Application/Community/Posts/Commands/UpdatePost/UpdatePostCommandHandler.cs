using AutoMapper;
using Evolvify.Application.Common.User;
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

namespace Evolvify.Application.Community.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,IUserContext userContext)
        {
            _userContext = userContext;
        
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.Id);
            var post= await _unitOfWork.Repository<Post, Guid>().GetByIdWithSpec(spec);
            
            if (post == null)
            {
                throw new NotFoundException("Post Not Found");
            }
            var userId = _userContext.GetCurrentUser().Id;
            var role = _userContext.GetCurrentUser().Role;



            if (post.UserId != userId && role!=UserRole.Admin)
            {
                throw new ForbiddenException("update", "post");
            }

            _mapper.Map(request, post);
            await _unitOfWork.CompleteAsync();
            
        }
    }
}
