using Evolvify.Domain.Entities.Assessment;
using Evolvify.Domain.Entities.Quiz;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evolvify.Application.Assessment.Service
{
    public interface IAssessmentApiService
    {
        Task<PredictionResponse> GetPredictionAsync(SkillAnswer answers);
        Task<List<SkillQuestions>> GetQuestionsAsync();

    }
}
