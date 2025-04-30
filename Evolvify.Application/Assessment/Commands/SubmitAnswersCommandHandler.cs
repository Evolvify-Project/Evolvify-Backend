using Evolvify.Application.Assessment.Service;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Specification.Skills;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Commands
{
    public class SubmitAnswersCommandHandler : IRequestHandler<SubmitAnswersCommand, ApiResponse<PredictionResponse>>
    {
        private readonly IAssessmentApiService _iAssessmentApiService;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
       
        public SubmitAnswersCommandHandler(IAssessmentApiService iAssessmentApiService, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _iAssessmentApiService = iAssessmentApiService;
        }
        public async Task<ApiResponse<PredictionResponse>> Handle(SubmitAnswersCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var assessmentResult = await _unitOfWork.AssessmentResultRepository.GetAllByUserId(userId);
            if (assessmentResult != null && assessmentResult.Any())
            {
                   return new ApiResponse<PredictionResponse>(false, StatusCodes.Status400BadRequest, "Assessment already completed.",null); 
            }

             var result = await _iAssessmentApiService.GetPredictionAsync(request.SkillAnswer);

            if (result == null)
            {
                throw new NotFoundException("Prediction result not found. ");
            }
            var listOfResults=new List<AssessmentResult>();
            var UserId=_userContext.GetCurrentUser().Id;

            foreach (var skillResult in result.Results)
            {
                var spec = new SkillSpecification();
                var skill = await _unitOfWork.Repository<Skill, int>().GetAllWithSpec(spec);
                var skillId = skill.FirstOrDefault(x => x.Name.ToLower() == skillResult.Skill.ToLower())?.Id;
                if (skillId == null)
                {
                    throw new NotFoundException($"Skill with name {skillResult.Skill} not found.");
                }
                var AssessmentData = new AssessmentResult
                {
                    SkillId = skillId.Value,
                    UserId = UserId,
                    Level = Enum.Parse<Level>(skillResult.Level)
                };

               listOfResults.Add(AssessmentData);

            }

            await _unitOfWork.AssessmentResultRepository.AddRangeAsync(listOfResults);

            await _unitOfWork.CompleteAsync();

            return new ApiResponse<PredictionResponse>(result);

        }
    }
}
