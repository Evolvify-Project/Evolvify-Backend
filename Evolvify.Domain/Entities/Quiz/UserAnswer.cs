using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Quiz
{
    public class UserAnswer : BaseEntity<int>
    {
        public int QuizAttemptId { get; set; }
        public QuizAttempt QuizAttempt { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; } = new Answer();

    }
}
