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

namespace Evolvify.Application.Community.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.Id);

            var post = await _unitOfWork.Repository<Post, Guid>().GetByIdWithSpec(spec);
            if (post == null)
            {
                throw new NotFoundException("Post Not Found");
            }

            _unitOfWork.Repository<Comment, Guid>().DeleteRange(post.Comments);
            _unitOfWork.Repository<Like, Guid>().DeleteRange(post.Likes);
            _unitOfWork.Repository<Post, Guid>().Delete(post);


            await _unitOfWork.CompleteAsync();
    
        }
    }
}
