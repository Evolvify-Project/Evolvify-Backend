using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications
{
    public class QuizAttemptSpecification : BaseSpecification<QuizAttempt, int>
    {
        public QuizAttemptSpecification(int id): base(q => q.Id == id)
        {
            AddInclude(q => q.Quiz.Questions);
            AddInclude(q => q.UserAnswers);
            AddInclude($"{nameof(QuizAttempt.UserAnswers)}.{nameof(UserAnswer.Answer)}");
        }

        public QuizAttemptSpecification(int? quizId, string? userId) : base(q =>
            (!quizId.HasValue || q.QuizId == quizId) && 
            (string.IsNullOrEmpty(userId) || q.UserId == userId))
        {

        }
    }
}
