using Evolvify.Domain.Entities.Community;
using Evolvify.Domain.Entities.Community.Likes;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.CommunitySpecification;
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

        public DeleteCommentOnPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCommentOnPostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostSpecification(request.PostId);
            var post = await _unitOfWork.Repository<Post,Guid>().GetByIdWithSpec(spec);
            
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
                _unitOfWork.Repository<CommentLike, Guid>().DeleteRange(comment.Likes);
                await _unitOfWork.CompleteAsync();

                if (comment.Replies.Any())
                {
                    DeleteReplies(comment.Replies);
                }
                await _unitOfWork.CompleteAsync();

                _unitOfWork.Repository<Comment, Guid>().Delete(comment);
                await _unitOfWork.CompleteAsync();

            }


        }
        private void DeleteReplies(IEnumerable<Comment> replies)
        {
            foreach (var reply in replies)
            {
                if (reply.Replies.Any())
                {
                    DeleteReplies(reply.Replies);
                }
                _unitOfWork.Repository<Comment, Guid>().Delete(reply);
            }
        }
    }
}
