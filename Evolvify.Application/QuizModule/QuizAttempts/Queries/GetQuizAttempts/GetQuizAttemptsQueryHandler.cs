using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttempts
{
    public class GetQuizAttemptsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetQuizAttemptsQuery, ApiResponse<IEnumerable<QuizAttemptDto>>>
    {
        public async Task<ApiResponse<IEnumerable<QuizAttemptDto>>> Handle(GetQuizAttemptsQuery request,
            CancellationToken cancellationToken)
        {
            if(request.QuizId.HasValue)
            {
                 var quiz = await unitOfWork.Repository<Quiz, int>().GetByIdWithSpec(new QuizSpecification(request.QuizId.Value)) ??
                       throw new NotFoundException(nameof(Quiz), request.QuizId.Value.ToString());
            }

            var quizAttempts = await unitOfWork.Repository<QuizAttempt, int>()
                .GetAllWithSpec(new QuizAttemptSpecification(request.QuizId, request.UserId));

            return new ApiResponse<IEnumerable<QuizAttemptDto>>(mapper.Map<List<QuizAttemptDto>>(quizAttempts));
        }
    }
}
