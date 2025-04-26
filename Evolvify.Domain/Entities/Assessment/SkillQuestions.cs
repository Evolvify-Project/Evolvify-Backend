using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Assessment
{
    public class SkillQuestions
    {
        public string QuestionId { get; set; }
        public string Code { get; set; } 
        public string QuestionText { get; set; } = string.Empty;
        public Dictionary<string, string> Choices { get; set; }

    }
}
