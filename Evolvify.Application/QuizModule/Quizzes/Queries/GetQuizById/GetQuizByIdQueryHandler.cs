using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Queries.GetQuizById
{
    public class GetQuizByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        : IRequestHandler<GetQuizByIdQuery, ApiResponse<QuizDto>>
    {
        public async Task<ApiResponse<QuizDto>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            var quiz = await unitOfWork.Repository<Quiz, int>().GetByIdWithSpec(new QuizSpecification(request.Id)) ??
                       throw new NotFoundException(nameof(Quiz), request.Id.ToString());

            return new ApiResponse<QuizDto>(mapper.Map<QuizDto>(quiz));
        }
    }
}
