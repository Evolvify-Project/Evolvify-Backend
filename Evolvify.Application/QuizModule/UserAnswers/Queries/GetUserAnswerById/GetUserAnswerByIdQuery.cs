using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.UserAnswers.Queries.GetUserAnswerById
{
    public class GetUserAnswerByIdQuery(int id) : IRequest<ApiResponse<UserAnswerDto>>
    {
        public int Id { get; } = id;
    }
}
