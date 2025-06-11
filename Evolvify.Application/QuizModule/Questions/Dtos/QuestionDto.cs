using Evolvify.Application.QuizModule.Answers.Dtos;

namespace Evolvify.Application.QuizModule.Questions.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public int QuizId { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
