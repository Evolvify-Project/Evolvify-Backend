using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttemptById
{
    public class GetQuizAttemptByIdQuery(int id): IRequest<ApiResponse<QuizAttemptDto>>
    {
        public int Id { get; } = id;
    }
}
