using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.AssessmentResult
{
    public class GetAssessmentResultQueryHandler : IRequestHandler<GetAssessmentResultQuery, ApiResponse<PredictionResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserContext userContext;

        public GetAssessmentResultQueryHandler(IUnitOfWork unitOfWork,IUserContext userContext)
        {
            this.unitOfWork = unitOfWork;
            this.userContext = userContext;
        }
        public async Task<ApiResponse<PredictionResponse>> Handle(GetAssessmentResultQuery request, CancellationToken cancellationToken)
        {
            var userId=userContext.GetCurrentUser().Id;
            var results=await unitOfWork.AssessmentResultRepository.GetAllByUserId(userId);
            if (!results.Any())
            {
                return new ApiResponse<PredictionResponse>(false,StatusCodes.Status404NotFound,"There is not Result Make Assessment First",null,null);
            }

            var result =new List<SkillResult>();
            foreach (var item in results)
            {
                var skillResult = new SkillResult() {
                    Skill = (await unitOfWork.Repository<Skill, int>().GetByIdAsync(item.SkillId)).Name,
                    Level = item.Level.ToString()
                };

                result.Add(skillResult);
            }

            var prediction = new PredictionResponse()
            {
                Results = result
            } ;
            return new ApiResponse<PredictionResponse>(prediction);

           
        }
    }
}
