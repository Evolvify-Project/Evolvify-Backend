using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Quiz
{
    public class UserAnswers : BaseEntity<int>
    {
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }=new ApplicationUser();
        public int QuestionId { get; set; }
        public Question Question { get; set; } = new Question();
        public int AnswerId { get; set; }
        public Answer Answer { get; set; } = new Answer();

    }
}
