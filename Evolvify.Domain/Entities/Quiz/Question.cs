using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Quiz
{
    public class Question:BaseEntity<int>
    {
        public string QuestionText { get; set; } = string.Empty;
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = new Quiz();
        public List<Answer> Answers { get; set; } = new List<Answer>();


    }
}
