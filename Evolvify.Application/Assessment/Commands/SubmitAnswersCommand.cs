using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Commands
{
    public class SubmitAnswersCommand : IRequest<ApiResponse<PredictionResponse>>
    {
        public SkillAnswer SkillAnswer { get; set; }
        public SubmitAnswersCommand(SkillAnswer skillAnswer)
        {
            SkillAnswer = skillAnswer;
        }

    }
}
