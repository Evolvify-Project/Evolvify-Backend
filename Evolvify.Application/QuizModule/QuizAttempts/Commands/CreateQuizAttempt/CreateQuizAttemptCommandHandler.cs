using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CreateQuizAttempt
{
    public class CreateQuizAttemptCommandHandler(IUnitOfWork unitOfWork, IUserContext userContext, IMapper mapper)
        : IRequestHandler<CreateQuizAttemptCommand, ApiResponse<QuizAttemptDto>>
    {
        public async Task<ApiResponse<QuizAttemptDto>> Handle(CreateQuizAttemptCommand request,
            CancellationToken cancellationToken)
        {
            var quiz = await unitOfWork.Repository<Quiz, int>().GetByIdWithSpec(new QuizSpecification(request.QuizId)) ??
                       throw new NotFoundException(nameof(Quiz), request.QuizId.ToString());

            var userId = userContext.GetCurrentUser().Id;

            var quizAttempt = new QuizAttempt() { UserId = userId, QuizId = request.QuizId, Quiz = quiz};

            var quizAttemptRepo = unitOfWork.Repository<QuizAttempt, int>();

            await quizAttemptRepo.CreateAsync(quizAttempt);
            await unitOfWork.CompleteAsync();

            var quizAttemptDto = mapper.Map<QuizAttemptDto>(quizAttempt);
            return new ApiResponse<QuizAttemptDto>(quizAttemptDto);
        }
    }
}
