using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Course : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public Level Level { get; set; }
        public int Duration { get; set; } // in minutes
        public ICollection<Module> Modules { get; set; }= new List<Module>();
       
    }
}
