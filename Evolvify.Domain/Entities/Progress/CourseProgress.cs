using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Progress
{
    public class CourseProgress
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Progress { get; set; } // Percentage of course completed
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }

        
    }
}
