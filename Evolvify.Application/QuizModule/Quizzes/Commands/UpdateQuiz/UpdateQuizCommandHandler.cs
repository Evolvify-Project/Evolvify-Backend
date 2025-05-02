using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdateQuizCommand, ApiResponse<QuizDto>>
    {
        public async Task<ApiResponse<QuizDto>> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Quiz, int>();

            var quiz = await repository.GetByIdWithSpec(new QuizSpecification(request.Id)) ??
                       throw new NotFoundException(nameof(Quiz), request.Id.ToString());

            mapper.Map(request, quiz);

            await unitOfWork.CompleteAsync();

            return new ApiResponse<QuizDto>(mapper.Map<QuizDto>(quiz));
        }
    }
}
