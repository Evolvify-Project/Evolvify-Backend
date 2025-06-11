using AutoMapper;
using Evolvify.Application.QuizModule.Quizzes.Commands.CreateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Commands.UpdateQuiz;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<CreateQuizCommand, Quiz>();
            CreateMap<UpdateQuizCommand, Quiz>();
            CreateMap<Quiz, QuizDto>().ReverseMap();
        }
    }
}
