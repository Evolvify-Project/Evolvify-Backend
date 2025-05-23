using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.User
{
    public class Subscription:BaseEntity<int>
    {
       
         public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string PlanType { get; set; } // "Free" or "Premium"
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } // "Active", "Expired", "Canceled"
    }
}
