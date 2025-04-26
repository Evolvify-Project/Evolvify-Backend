using Evolvify.Application.Assessment.Service;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Exceptions;
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
        public SubmitAnswersCommandHandler(IIAssessmentApiService huggingFaceApiService)
        {
            _huggingFaceApiService = huggingFaceApiService;
        }
        public async Task<ApiResponse<PredictionResponse>> Handle(SubmitAnswersCommand request, CancellationToken cancellationToken)
        {
             var result = await _huggingFaceApiService.GetPredictionAsync(request.SkillAnswer);

            if (result == null)
            {
                throw new NotFoundException("Prediction result not found. ");
            }

              return new ApiResponse<PredictionResponse>(result);

        }
    }
}
