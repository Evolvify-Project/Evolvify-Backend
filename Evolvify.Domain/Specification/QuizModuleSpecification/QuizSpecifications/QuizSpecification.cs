using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications
{
    public class QuizSpecification : BaseSpecification<Quiz, int>
    {
        public QuizSpecification()
        {
            
        }
        public QuizSpecification(int id) : base(q => q.Id == id)
        {
        }
    }
}
