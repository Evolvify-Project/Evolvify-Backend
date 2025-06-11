using AutoMapper;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class QuizAttemptProfile : Profile
    {
        public QuizAttemptProfile()
        {
            CreateMap<QuizAttempt, QuizAttemptDto>().ReverseMap();
        }
    }
}
