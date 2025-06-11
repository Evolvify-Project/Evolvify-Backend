using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Domain.Specification.QuizModuleSpecification.AnswerSpecifications
{
    public class AnswerSpecification(int id) : BaseSpecification<Answer, int>(a => a.Id == id);
}
