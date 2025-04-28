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
        private readonly IIAssessmentApiService _huggingFaceApiService;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
       
        public SubmitAnswersCommandHandler(IIAssessmentApiService huggingFaceApiService, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _huggingFaceApiService = huggingFaceApiService;
        }
        public async Task<ApiResponse<PredictionResponse>> Handle(SubmitAnswersCommand request, CancellationToken cancellationToken)
        {
             var result = await _huggingFaceApiService.GetPredictionAsync(request.SkillAnswer);

            if (result == null)
            {
                throw new NotFoundException("Prediction result not found. ");
            }

            var UserId=_userContext.GetCurrentUser().Id;
            foreach (var skillResult in result.Results)
            {
                var spec = new SkillSpecification();
                var skill = await _unitOfWork.Repository<Skill, int>().GetAllWithSpec(spec);
                var skillId = skill.FirstOrDefault(x => x.Name == skillResult.Skill)?.Id;
                if (skillId == null)
                {
                    throw new NotFoundException($"Skill with name {skillResult.Skill} not found.");
                }
                var assessmentResult = new AssessmentResult
                {
                    SkillId = skillId.Value,
                    UserId = UserId,
                    Level = Enum.Parse<Level>(skillResult.Level)
                };

                await _unitOfWork.Repository<AssessmentResult, int>().CreateAsync(assessmentResult);

            }
            await _unitOfWork.CompleteAsync();

            return new ApiResponse<PredictionResponse>(result);

        }
    }
}
