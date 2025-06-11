using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;

namespace Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        : IRequestHandler<CreateQuizCommand, ApiResponse<QuizDto>>
    {
        public async Task<ApiResponse<QuizDto>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = mapper.Map<Quiz>(request);

            await unitOfWork.Repository<Quiz, int>().CreateAsync(quiz);
            await unitOfWork.CompleteAsync();

            return new ApiResponse<QuizDto>(mapper.Map<QuizDto>(quiz));
        }
    }
}
