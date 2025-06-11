using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Domain.Specification.QuizModuleSpecification.QuestionSpecifications
{
    public class QuestionSpecification : BaseSpecification<Question, int>
    {
        public QuestionSpecification(int? quizId) : base(q => (!quizId.HasValue || q.QuizId == quizId))
        {
            AddInclude(q => q.Answers);
        }
        public QuestionSpecification(int id): base(q => q.Id == id)
        {
            AddInclude(q => q.Answers);
        }
    }
}
