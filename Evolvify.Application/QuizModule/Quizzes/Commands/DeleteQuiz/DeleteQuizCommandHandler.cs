using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteQuizCommand>
    {
        public async Task Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await unitOfWork.Repository<Quiz, int>().GetByIdWithSpec(new QuizSpecification(request.Id)) ??
                       throw new NotFoundException(nameof(Quiz), request.Id.ToString());

            unitOfWork.Repository<Quiz, int>().Delete(quiz);
            await unitOfWork.CompleteAsync();

        }
    }
}
