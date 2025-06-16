using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Interfaces;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CalculateQuizAttemptResult
{
    public class CalculateQuizAttemptResultCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CalculateQuizAttemptResultCommand, ApiResponse<QuizResultDto>>
    {
        public async Task<ApiResponse<QuizResultDto>> Handle(CalculateQuizAttemptResultCommand request,
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

            var result = questionsCount > 0 ? ((double)CorrectAnswersCount / questionsCount) * 100 : 0;
            quizAttempt.Score = result;

            await unitOfWork.CompleteAsync();

           var score = new QuizResultDto
            {
                Score = new ScoreDto
                {
                    Correct = CorrectAnswersCount,
                    Total = questionsCount
                },
                Percentage = $"{result:F2}%" // Format to two decimal places
            };
            return new ApiResponse<QuizResultDto>(score);
        }
    }
}
