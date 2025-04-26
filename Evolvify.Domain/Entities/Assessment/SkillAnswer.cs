using System.Text.Json.Serialization;

namespace Evolvify.Domain.Entities.Assessment
{
    public class SectionAnswer
    {
        [JsonPropertyName("Q1")]
        public string Q1 { get; set; } = string.Empty;

        [JsonPropertyName("Q2")]
        public string Q2 { get; set; } = string.Empty;

        [JsonPropertyName("Q3")]
        public string Q3 { get; set; } = string.Empty;

        [JsonPropertyName("Q4")]
        public string Q4 { get; set; } = string.Empty;

        [JsonPropertyName("Q5")]
        public string Q5 { get; set; } = string.Empty;

        [JsonPropertyName("Q6")]
        public string Q6 { get; set; } = string.Empty;
    }

    public class SkillAnswer
    {
        [JsonPropertyName("interview")]
        public SectionAnswer Interview { get; set; }

        [JsonPropertyName("communication")]
        public SectionAnswer Communication { get; set; }

        [JsonPropertyName("time_management")]
        public SectionAnswer Time_Management { get; set; }

        [JsonPropertyName("presentation")]
        public SectionAnswer Presentation { get; set; }

        [JsonPropertyName("teamwork")]
        public SectionAnswer Teamwork { get; set; }
    }
}
