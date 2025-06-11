using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttempts
{
    public class GetQuizAttemptsQuery(int? quizId, string? userId) : IRequest<ApiResponse<IEnumerable<QuizAttemptDto>>>
    {
        public int? QuizId { get; } = quizId;
        public string? UserId { get; } = userId;
    }
}
