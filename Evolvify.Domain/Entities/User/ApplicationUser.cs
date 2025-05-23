using Evolvify.Domain.Entities.Community;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? TrialStartDate { get; set; }
        public DateTime? TrialEndDate { get; set; }
        public string? ProfileImageUrl { get; set; }

        [ForeignKey("Subscription")]
        public int? SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }
    }
}
