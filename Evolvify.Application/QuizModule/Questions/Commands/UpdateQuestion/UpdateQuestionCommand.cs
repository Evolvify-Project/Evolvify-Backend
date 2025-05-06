using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Answers.Dtos;
using Evolvify.Application.QuizModule.Questions.Dtos;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest<ApiResponse<QuestionDto>>
    {
    public int Id { get; set; }
    public int QuestionNumber { get; set; }
    public string QuestionText { get; set; }
    public int QuizId { get; set; }
    public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();

    }
}
