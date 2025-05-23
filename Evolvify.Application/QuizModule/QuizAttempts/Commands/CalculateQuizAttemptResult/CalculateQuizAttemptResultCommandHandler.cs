using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CalculateQuizAttemptResult
{
    public class CalculateQuizAttemptResultCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CalculateQuizAttemptResultCommand, ApiResponse<double>>
    {
        public async Task<ApiResponse<double>> Handle(CalculateQuizAttemptResultCommand request,
            CancellationToken cancellationToken)
        {
            var quizAttemptRepo = unitOfWork.Repository<QuizAttempt, int>();

            var quizAttempt = await quizAttemptRepo.GetByIdWithSpec(new QuizAttemptSpecification(request.QuizAttemptId)) ??
                              throw new NotFoundException(nameof(QuizAttempt), request.QuizAttemptId.ToString());

            var questionsCount = quizAttempt.Quiz.Questions.Count;
            var CorrectAnswersCount = 0;

            foreach (var userAnswer in quizAttempt.UserAnswers)
            {
                if (userAnswer.Answer.IsCorrect)
                    CorrectAnswersCount++;
            }

            var result = questionsCount > 0 ? (double)CorrectAnswersCount / questionsCount * 100 : 0;
            quizAttempt.Score = result;

            await unitOfWork.CompleteAsync();
            return new ApiResponse<double>(result);
        }
    }
}
