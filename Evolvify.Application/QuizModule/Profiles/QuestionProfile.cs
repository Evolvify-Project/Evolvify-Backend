using AutoMapper;
using Evolvify.Application.QuizModule.Questions.Commands.CreateQuestion;
using Evolvify.Application.QuizModule.Questions.Commands.UpdateQuestion;
using Evolvify.Application.QuizModule.Questions.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<UpdateQuestionCommand, Question>();
        }
    }
}
