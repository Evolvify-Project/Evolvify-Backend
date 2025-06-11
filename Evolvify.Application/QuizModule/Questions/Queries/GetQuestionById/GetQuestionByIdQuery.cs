using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Questions.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Queries.GetQuestionById
{
    public class GetQuestionByIdQuery(int id) : IRequest<ApiResponse<QuestionDto>>
    {
        public int Id { get; } = id;
    }
}
