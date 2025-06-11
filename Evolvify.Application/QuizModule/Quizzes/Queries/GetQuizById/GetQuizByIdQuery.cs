using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Queries.GetQuizById
{
    public class GetQuizByIdQuery(int id) : IRequest<ApiResponse<QuizDto>>
    {
        public int Id { get; } = id;
    }
}
