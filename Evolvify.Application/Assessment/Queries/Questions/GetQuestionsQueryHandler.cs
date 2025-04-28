using Evolvify.Application.Assessment.Service;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries.Questions
{
    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, ApiResponse<List<SkillQuestions>>>
    {
        private readonly IIAssessmentApiService _huggingFaceApiService;
        public GetQuestionsQueryHandler(IIAssessmentApiService huggingFaceApiService)
        {
            _huggingFaceApiService = huggingFaceApiService;
        }
        public async Task<ApiResponse<List<SkillQuestions>>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var question = await _huggingFaceApiService.GetQuestionsAsync();

            if (question == null)
            {
                throw new NotFoundException("Questions not found");
            }
            return new ApiResponse<List<SkillQuestions>>(question);


        }
    }

}
