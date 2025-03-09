using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Community.Comments.Commands.DeleteComment
{
    public class DeleteCommentOnPostCommandHandler : IRequestHandler<DeleteCommentOnPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public async Task Handle(DeleteCommentOnPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post,Guid>().GetByIdAsync(request.PostId);
            
            if (post == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId.ToString());
            }

            var comment = post.Comments.FirstOrDefault(x => x.Id == request.CommentId);
            if (comment == null)
            {
                throw new NotFoundException(nameof(Comment), request.CommentId.ToString());
            }
            else
            {
                _unitOfWork.Repository<Comment, Guid>().Delete(comment);
                await _unitOfWork.CompleteAsync();
            }


        }
    }
}
