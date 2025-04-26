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
    public class AssessmentApiService : IIAssessmentApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://moodydev-Assessment.hf.space/predict";

        public AssessmentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PredictionResponse> GetPredictionAsync(SkillAnswer answers)
        {


            var response = await _httpClient.PostAsJsonAsync(ApiUrl, answers);
            
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var predictionResponse = JsonConvert.DeserializeObject<PredictionResponse>(responseString);

            if (predictionResponse == null)
            {
                throw new Exception("Failed to deserialize the response.");
            }

            return predictionResponse;
        }

        public async Task<List<SkillQuestions>> GetQuestionsAsync()
        {
            var response = await _httpClient.GetAsync("https://moodydev-Assessment.hf.space/questions");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var questions = JsonConvert.DeserializeObject<List<SkillQuestions>>(responseString);

            if (questions == null)
            {
                throw new Exception("Failed to deserialize the response.");
            }

            return questions;
        }
    }
}
