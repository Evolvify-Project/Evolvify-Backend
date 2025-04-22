using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities
{
    public class Module:BaseEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public Course Course { get; set; } 
        public int CourseId { get; set; }
        public ICollection<Content> Contents { get; set; } = new List<Content>();

    }
}
