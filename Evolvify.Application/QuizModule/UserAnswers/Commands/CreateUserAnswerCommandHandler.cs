using AutoMapper;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using Evolvify.Domain.Entities.Quiz;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.QuizModuleSpecification.AnswerSpecifications;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizAttemptSpecifications;
using Evolvify.Domain.Specification.QuizModuleSpecification.QuizSpecifications;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using MimeKit.Cryptography;

namespace Evolvify.Application.QuizModule.UserAnswers.Commands
{
    public class CreateUserAnswerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<CreateUserAnswerCommand, ApiResponse<UserAnswerDto>>
    {
        public async Task<ApiResponse<UserAnswerDto>> Handle(CreateUserAnswerCommand request, CancellationToken cancellationToken)
        {
            var quizAttempt = await unitOfWork.Repository<QuizAttempt, int>().GetByIdWithSpec(new QuizAttemptSpecification(request.QuizAttemptId)) ??
                       throw new NotFoundException(nameof(QuizAttempt), request.QuizAttemptId.ToString());
             
            var answer = await unitOfWork.Repository<Answer, int>().GetByIdWithSpec(new AnswerSpecification(request.AnswerId)) ??
                       throw new NotFoundException(nameof(Answer), request.AnswerId.ToString());


            var userAnswer = new UserAnswer { AnswerId = request.AnswerId, Answer = answer, QuizAttemptId = request.QuizAttemptId,QuestionId=answer.QuestionId};

            var userAnswerRepo = unitOfWork.Repository<UserAnswer, int>();

            await userAnswerRepo.CreateAsync(userAnswer);
            await unitOfWork.CompleteAsync();

            var userAnswerDto = mapper.Map<UserAnswerDto>(userAnswer);
            return new ApiResponse<UserAnswerDto>(userAnswerDto);
        }
    }
}
