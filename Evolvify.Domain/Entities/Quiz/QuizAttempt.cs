using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Quiz
{
    public class QuizAttempt : BaseEntity<int>
    {
        public double Score { get; set; } 
        public string? Duration { get; set; } 
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = new ApplicationUser();
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = new Quiz();
        public List<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

    }
}
