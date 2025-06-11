using AutoMapper;
using Evolvify.Application.QuizModule.Answers.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<CreateAnswerDto, Answer>();
        }
    }
}
