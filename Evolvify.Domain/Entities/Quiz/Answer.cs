using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Quiz
{
    public class Answer : BaseEntity<int>
    {
        public string AnswerText { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = new Question();
        public bool IsCorrect { get; set; } = false;


    }
}
