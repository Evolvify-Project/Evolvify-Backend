using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Questions.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuestionSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetAllQuestionQuery, ApiResponse<IEnumerable<QuestionDto>>>
    {
        public async Task<ApiResponse<IEnumerable<QuestionDto>>> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
        {
            var questions = await unitOfWork.Repository<Question, int>().GetAllWithSpec(new QuestionSpecification(request.QuizId));

            return new ApiResponse<IEnumerable<QuestionDto>>(mapper.Map<List<QuestionDto>>(questions));
        }
    }
}
