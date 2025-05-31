using Evolvify.Domain.Enums;
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
        public string UserId { get; set; }
        public PlanType PlanType { get; set; } // "Free" or "Premium"
        public string? StripeSubscriptionId { get; set; }
        public string? StripePriceId { get; set; } // The price ID from Stripe
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; } // "Active", "Expired", "Canceled"
        public SubscriptionInterval? Interval { get; set; }

    }
}
