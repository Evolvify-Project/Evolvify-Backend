using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Questions.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Queries.GetAllQuestion
{
    public class GetAllQuestionQuery(int? quizId) : IRequest<ApiResponse<IEnumerable<QuestionDto>>>
    {
        public int? QuizId { get; } = quizId;
    }
}
