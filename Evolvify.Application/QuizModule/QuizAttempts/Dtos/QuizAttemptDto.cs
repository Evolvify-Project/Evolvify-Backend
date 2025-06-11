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
        public double Score { get; set; }
        public string? Duration { get; set; }
        public string UserId { get; set; }
        public int QuizId { get; set; }

    }
}
