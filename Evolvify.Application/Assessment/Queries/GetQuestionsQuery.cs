using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities.Assessment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Queries
{
    public class GetQuestionsQuery:IRequest<ApiResponse<List<SkillQuestions>>>
    {
    }
}
