using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.AppSubscription.DTOs
{
    public class SubscriptionPlanDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StripePriceId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Interval { get; set; } 
    }
}
