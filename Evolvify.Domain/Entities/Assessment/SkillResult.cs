using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Assessment
{
    public class SkillResult
    {
        public string Skill {  get; set; }
        public string Level { get; set; }
    }

    public class PredictionResponse
    {
        public List<SkillResult> Results { get; set; }
    }
}
