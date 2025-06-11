using Evolvify.Application.DTOs.Response;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
