using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Skill:BaseEntity<int>
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
