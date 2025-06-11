using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CalculateQuizAttemptResult
{
    public class CalculateQuizAttemptResultCommand(int quizAttemptId) : IRequest<ApiResponse<double>>
    {
        public int QuizAttemptId { get; } = quizAttemptId;
    }
}
