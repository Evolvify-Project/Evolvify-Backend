using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Assessment
{
    public class AssessmentResult: BaseEntity<int>
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Level Level { get; set; }

    }
}
