using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Questions.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
