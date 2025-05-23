using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolvify.Domain.Entities.User;

namespace Evolvify.Domain.Entities.Progress
{
    public class ModuleProgress
    {
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Progress { get; set; } // Percentage of module completed
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        

    }
}
