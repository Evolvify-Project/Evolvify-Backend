using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.UserAnswers.Queries.GetAllUserAnswers
{
    public class GetAllUserAnswersQuery(int? quizAttemptId) : IRequest<ApiResponse<IEnumerable<UserAnswerDto>>>
    {
        public int? QuizAttemptId { get; } = quizAttemptId;
    }
}
