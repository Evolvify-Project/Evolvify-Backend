using AutoMapper;
using Evolvify.Application.QuizModule.UserAnswers.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class UserAnswerProfile : Profile
    {
        public UserAnswerProfile()
        {
            CreateMap<UserAnswer, UserAnswerDto>();
        }
    }
}
