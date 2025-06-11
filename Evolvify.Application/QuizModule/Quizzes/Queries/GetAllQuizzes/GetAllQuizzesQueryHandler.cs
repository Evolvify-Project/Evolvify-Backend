using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Queries.GetAllQuizzes
{
    public class GetAllQuizzesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        : IRequestHandler<GetAllQuizzesQuery, ApiResponse<IEnumerable<QuizDto>>>
    {
        public async Task<ApiResponse<IEnumerable<QuizDto>>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            var quizzes = await unitOfWork.Repository<Quiz, int>().GetAllWithSpec(new QuizSpecification());

            return new ApiResponse<IEnumerable<QuizDto>>(mapper.Map<List<QuizDto>>(quizzes));
        }
    }
}
