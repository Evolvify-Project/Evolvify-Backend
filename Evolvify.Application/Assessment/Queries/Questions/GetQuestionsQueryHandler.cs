using Evolvify.Application.Assessment.Service;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Exceptions;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.Questions
{
    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, ApiResponse<List<SkillQuestions>>>
    {
        private readonly IAssessmentApiService _iAssessmentApiService;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        public GetQuestionsQueryHandler(IAssessmentApiService iAssessmentApiService,IUserContext userContext,IUnitOfWork unitOfWork)
        {
            _iAssessmentApiService = iAssessmentApiService;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<List<SkillQuestions>>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var assessmentResult = await _unitOfWork.AssessmentResultRepository.GetAllByUserId(userId);
            if (assessmentResult != null && assessmentResult.Any())
            {
                return new ApiResponse<List<SkillQuestions>> (false, StatusCodes.Status400BadRequest,"Assessment already completed.", null);
            }

            var question = await _iAssessmentApiService.GetQuestionsAsync();

            if (question == null)
            {
                throw new NotFoundException("Questions not found");
            }
            return new ApiResponse<List<SkillQuestions>>(question);


        }
    }

}
