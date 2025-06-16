namespace Evolvify.Application.QuizModule.UserAnswers.Dtos
{
    public class UserAnswerDto
    {
        public int Id { get; set; }
        public int QuizAttemptId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }


    }
}
