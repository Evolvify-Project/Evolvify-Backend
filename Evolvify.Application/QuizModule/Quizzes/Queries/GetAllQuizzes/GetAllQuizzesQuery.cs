using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Queries.GetAllQuizzes
{
    public class GetAllQuizzesQuery : IRequest<ApiResponse<IEnumerable<QuizDto>>>
    {
    }
}
