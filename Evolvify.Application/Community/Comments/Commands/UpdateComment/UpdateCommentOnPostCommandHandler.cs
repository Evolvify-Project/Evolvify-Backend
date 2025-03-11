using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Commands.UpdateComment
{
    public class UpdateCommentOnPostCommandHandler : IRequestHandler<UpdateCommentOnPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCommentOnPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public async Task Handle(UpdateCommentOnPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post, Guid>().GetByIdAsync(request.PostId);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId.ToString());
            }

            var comment = post.Comments.FirstOrDefault(x => x.Id == request.CommentId);
            if (comment == null)
            {
                   throw new NotFoundException(nameof(Comment), request.CommentId.ToString());
            }

            comment.Content = request.Content;

            await _unitOfWork.CompleteAsync();


            
        }
    }
}
