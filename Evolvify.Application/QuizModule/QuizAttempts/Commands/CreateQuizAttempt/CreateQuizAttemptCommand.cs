using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Commands.CreateQuizAttempt
{
    public class CreateQuizAttemptCommand: IRequest<ApiResponse<QuizAttemptDto>>
    {
        public int QuizId { get; set; }
    }
}
