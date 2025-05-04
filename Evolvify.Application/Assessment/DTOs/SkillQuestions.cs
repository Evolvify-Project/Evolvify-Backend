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
        public Options Choices { get; set; } 
    }

    public class Options
    {
        public string A { get; set; } = string.Empty;
        public string B { get; set; } = string.Empty;
        public string C { get; set; } = string.Empty;
        public string D { get; set; } = string.Empty;
    }
    

}
