using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Answers.Dtos;
using Evolvify.Application.QuizModule.Questions.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuestionSpecifications;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Queries.GetQuestionById
{
    public class GetQuestionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetQuestionByIdQuery, ApiResponse<QuestionDto>>
    {
        public async Task<ApiResponse<QuestionDto>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var question = await unitOfWork.Repository<Question, int>().GetByIdWithSpec(new QuestionSpecification(request.Id)) ??
                       throw new NotFoundException(nameof(Question), request.Id.ToString());

            var questionDto = mapper.Map<QuestionDto>(question);

            return new ApiResponse<QuestionDto>(questionDto);

        }
    }
}
