using Evolvify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Skill:BaseEntity<int>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? SkillImage { get; set; } 
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        

    }
}
