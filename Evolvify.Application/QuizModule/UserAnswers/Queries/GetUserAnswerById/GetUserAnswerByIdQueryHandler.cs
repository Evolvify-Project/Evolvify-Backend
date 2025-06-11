using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.UserAnswerSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.UserAnswers.Queries.GetUserAnswerById
{
    public class GetUserAnswerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetUserAnswerByIdQuery, ApiResponse<UserAnswerDto>>
    {
        public async Task<ApiResponse<UserAnswerDto>> Handle(GetUserAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var userAnswer = await unitOfWork.Repository<UserAnswer, int>().GetByIdWithSpec(new UserAnswerSpecification(request.Id)) ??
                              throw new NotFoundException(nameof(QuizAttempt), request.Id.ToString());

            return new ApiResponse<UserAnswerDto>(mapper.Map<UserAnswerDto>(userAnswer));
        }
    }
}
