using AutoMapper;
using Evolvify.Application.Courses.Queries.GetAll;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Specification.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Courses.DTOs
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {

            CreateMap<Course, CourseDetialsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.ToString()))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Duration).ToString(@"hh\:mm")))
                .ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.Modules))
                .ForMember(dest => dest.NumberOfModules, opt => opt.MapFrom(src => src.Modules.Count()));


            CreateMap<Course, CoursesListDto>()
                .ForMember(dest => dest.Skill, opt => opt.MapFrom(src => src.Skill.Name))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.ToString()))
                .ForMember(dest => dest.Duration, opt=> opt.MapFrom(src => TimeSpan.FromMinutes(src.Duration).ToString(@"hh\:mm")));


            CreateMap<GetAllCoursesQuery, CourseParameters>();
        }
    }
}
