using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.UserAnswers.Commands
{
    public class CreateUserAnswerCommand : IRequest<ApiResponse<UserAnswerDto>>
    {
        public int QuizAttemptId { get; set; }
        public int AnswerId { get; set; }

    }
}
