using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Answers.Dtos;
using Evolvify.Application.QuizModule.Questions.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        : IRequestHandler<CreateQuestionCommand, ApiResponse<QuestionDto>>
    {
        public async Task<ApiResponse<QuestionDto>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var quiz = await unitOfWork.Repository<Quiz, int>().GetByIdWithSpec(new QuizSpecification(request.QuizId)) ??
                       throw new NotFoundException(nameof(Quiz), request.QuizId.ToString());

            var question = mapper.Map<Question>(request);
            question.Quiz = quiz; // why quiz does not map automatic?????? 
            await unitOfWork.Repository<Question, int>().CreateAsync(question);

            await unitOfWork.CompleteAsync();

            var questionDto = mapper.Map<QuestionDto>(question);

            return new ApiResponse<QuestionDto>(questionDto);
        }
    }
}
