using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Services.AppSubscription.DTOs
{
    public class SubscriptionStatusDto
    {
        public string Plan { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Interval { get; set; } 
        public int RemainingDays { get; set; }
    }
}
