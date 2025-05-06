using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Questions.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuestionSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdateQuestionCommand, ApiResponse<QuestionDto>>
    {
        public async Task<ApiResponse<QuestionDto>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Question, int>();

            var question = await repository.GetByIdWithSpec(new QuestionSpecification(request.Id)) ??
                           throw new NotFoundException(nameof(Question), request.Id.ToString());

            mapper.Map(request, question);
            await unitOfWork.CompleteAsync();
            return new ApiResponse<QuestionDto>(mapper.Map<QuestionDto>(question));
        }
    }
}
