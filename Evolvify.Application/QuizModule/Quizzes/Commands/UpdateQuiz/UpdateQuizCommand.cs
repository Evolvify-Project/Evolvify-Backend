using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommand : QuizDto, IRequest<ApiResponse<QuizDto>>
    {
    }
}
