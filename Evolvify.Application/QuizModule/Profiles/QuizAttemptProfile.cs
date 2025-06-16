using AutoMapper;
using Evolvify.Application.QuizModule.QuizAttempts.Dtos;
using Evolvify.Application.QuizModule.Quizzes.Dtos;
using Evolvify.Domain.Entities.Quiz;

namespace Evolvify.Application.QuizModule.Profiles
{
    public class QuizAttemptProfile : Profile
    {
        public QuizAttemptProfile()
        {
            CreateMap<QuizAttempt, QuizAttemptDto>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => new QuizResultDto
                {
                    Percentage = $"{src.Score} %",
                    Score = new ScoreDto
                    {
                        Total = src.Quiz.Questions.Count,
                        Correct = src.UserAnswers.Count(ua => ua.Answer.IsCorrect)
                    }
                }))
                .ForMember(dest => dest.userAnswers, opt => opt.MapFrom(src => src.UserAnswers))
                .ReverseMap();

        }
    }
}
