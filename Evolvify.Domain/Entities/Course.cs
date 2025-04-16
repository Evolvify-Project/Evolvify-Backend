using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Course :BaseEntity<int>
    {
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public Level Level { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; } = new Skill();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
