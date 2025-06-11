using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Domain.Specification.QuizModuleSpecification.UserAnswerSpecifications
{
    public class UserAnswerSpecification : BaseSpecification<UserAnswer, int>
    {
        public UserAnswerSpecification(int? quizAttemptId) : base(u =>
            (!quizAttemptId.HasValue || u.QuizAttemptId == quizAttemptId))
        {

        }

        public UserAnswerSpecification(int id) : base(u => u.Id == id)
        {
        }
    }
}
