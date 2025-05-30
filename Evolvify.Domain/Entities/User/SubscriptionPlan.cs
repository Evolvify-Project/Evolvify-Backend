using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.User
{
    public class SubscriptionPlan:BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public string StripePriceId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public SubscriptionInterval Interval { get; set; } // e.g., "month", "year"

    }
}
