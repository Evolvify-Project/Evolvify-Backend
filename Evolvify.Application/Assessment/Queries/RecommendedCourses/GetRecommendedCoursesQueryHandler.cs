using AutoMapper;
using Evolvify.Application.Assessment.Queries.RecommendedCourses.DTOs;
using Evolvify.Application.Common.User;
using Evolvify.Application.Courses.DTOs;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Courses;
using Evolvify.Domain.Specification.Skills;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.RecommendedCourses
{
    public class GetRecommendedCoursesQueryHandler:IRequestHandler<GetRecommendedCoursesQuery, ApiResponse<IEnumerable<RecommendedCoursesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public GetRecommendedCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserContext userContext)
        {
            _userContext = userContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<IEnumerable<RecommendedCoursesResponse>>> Handle(GetRecommendedCoursesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var assessmentResults = await _unitOfWork.AssessmentResultRepository.GetAllByUserId(userId);
            if (assessmentResults == null || !assessmentResults.Any())
            {
                throw new NotFoundException("No assessment results found for the user. Please complete the assessment first.");
            }

            var recommendedCourses = new List<RecommendedCoursesResponse>();

            foreach (var assessmentResult in assessmentResults)
            {
                var skill = await _unitOfWork.Repository<Skill,int>().GetByIdAsync(assessmentResult.SkillId);
                var level=assessmentResult.Level;
                var courses = await _unitOfWork.Repository<Course,int>().GetAllWithSpec(new CourseSpecification(skill.Id, level));

                var recommendedCoursesForSkill =new RecommendedCoursesResponse
                {
                    Skill = skill.Name,
                    Level = level.ToString(),
                    Courses = _mapper.Map<List<CoursesListDto>>(courses),
                };
                recommendedCourses.Add(recommendedCoursesForSkill);               
            }

            return new ApiResponse<IEnumerable<RecommendedCoursesResponse>>(recommendedCourses); 
            
        }
    }
    
}
