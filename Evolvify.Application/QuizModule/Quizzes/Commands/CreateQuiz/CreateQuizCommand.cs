using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz
{
    public class CreateQuizCommand : IRequest<ApiResponse<QuizDto>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;

    }
}
