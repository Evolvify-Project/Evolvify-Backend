using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CalculateQuizAttemptResult
{
    public class CalculateQuizAttemptResultCommand(int quizAttemptId) : IRequest<ApiResponse<QuizResultDto>>
    {
        public int QuizAttemptId { get; } = quizAttemptId;
    }
}
