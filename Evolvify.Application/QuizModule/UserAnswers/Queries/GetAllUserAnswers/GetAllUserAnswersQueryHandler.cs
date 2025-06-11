using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Specification.QuizModuleSpecification.UserAnswerSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.UserAnswers.Queries.GetAllUserAnswers
{
    public class GetAllUserAnswersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetAllUserAnswersQuery, ApiResponse<IEnumerable<UserAnswerDto>>>
    {
        public async Task<ApiResponse<IEnumerable<UserAnswerDto>>> Handle(GetAllUserAnswersQuery request, CancellationToken cancellationToken)
        {
            var userAnswers = await unitOfWork.Repository<UserAnswer, int>()
                .GetAllWithSpec(new UserAnswerSpecification(request.QuizAttemptId));

            return new ApiResponse<IEnumerable<UserAnswerDto>>(mapper.Map<List<UserAnswerDto>>(userAnswers));
        }
    }
}
