using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.QuizAttempts.Queries.GetQuizAttemptById
{
    public class GetQuizAttemptByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetQuizAttemptByIdQuery, ApiResponse<QuizAttemptDto>>
    {
        public async Task<ApiResponse<QuizAttemptDto>> Handle(GetQuizAttemptByIdQuery request,
            CancellationToken cancellationToken)
        {
            var quizAttempt = await unitOfWork.Repository<QuizAttempt, int>().GetByIdWithSpec(new QuizAttemptSpecification(request.Id)) ??
                              throw new NotFoundException(nameof(QuizAttempt), request.Id.ToString());

            return new ApiResponse<QuizAttemptDto>(mapper.Map<QuizAttemptDto>(quizAttempt));
        }
    }
}
