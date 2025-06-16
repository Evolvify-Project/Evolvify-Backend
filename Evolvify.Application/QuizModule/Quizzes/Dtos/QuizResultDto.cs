using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.QuizModule.Quizzes.Dtos
{
    public class ScoreDto
    {
        public int Correct { get; set; }
        public int Total { get; set; }
    }
    public class QuizResultDto
    {
        public ScoreDto Score { get; set; }
        public string Percentage { get; set; }
   

    }
}
