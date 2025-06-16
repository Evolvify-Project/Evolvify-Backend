using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.QuizModule.QuizAttempts.Dtos
{
    public class QuizAttemptDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public QuizResultDto Result { get; set; } = new QuizResultDto();
        public string? Duration { get; set; }
        public string UserId { get; set; }
        public int QuizId { get; set; }

        public List<UserAnswerDto> userAnswers { get; set; } = new List<UserAnswerDto>();

    }
}
