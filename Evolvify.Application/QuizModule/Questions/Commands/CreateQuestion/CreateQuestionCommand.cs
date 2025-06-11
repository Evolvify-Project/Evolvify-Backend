using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Answers.Dtos;
using Evolvify.Application.QuizModule.Questions.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<ApiResponse<QuestionDto>>
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public int QuizId { get; set; }
        public List<CreateAnswerDto> Answers { get; set; } = new List<CreateAnswerDto>();

    }
}
