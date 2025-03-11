using AutoMapper;
using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
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

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post= await _unitOfWork.Repository<Post,Guid>().GetByIdAsync(request.Id);
            
            if (post == null)
            {
                throw new NotFoundException("Post Not Found");
            }

            _mapper.Map(request, post);
            await _unitOfWork.CompleteAsync();
            
        }
    }
}
