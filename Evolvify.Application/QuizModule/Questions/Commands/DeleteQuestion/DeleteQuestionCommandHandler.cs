using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuestionSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteQuestionCommand>
    {
        public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Question, int>();

            var question = await repository.GetByIdWithSpec(new QuestionSpecification(request.Id)) ??
                           throw new NotFoundException(nameof(Question), request.Id.ToString());

            repository.Delete(question);
            await unitOfWork.CompleteAsync();
        }
    }
}
