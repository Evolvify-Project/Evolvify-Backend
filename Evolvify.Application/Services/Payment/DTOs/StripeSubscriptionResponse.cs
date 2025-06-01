using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.Payment.DTOs
{
    public class StripeSubscriptionResponse
    {
        public string ClientSecret { get; set; }
        public string StripeSubscriptionId { get; set; }
        public string StripeCustomerId { get; set; }
    }
}

