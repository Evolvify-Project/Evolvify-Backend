using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using Evolvify.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Infrastructure.Configurations.SubscriptionConfigurations
{
    public class ActiveSubscriptionSpecification : BaseSpecification<Subscription,int>
    {
        public ActiveSubscriptionSpecification(string priceId, string userId) 
            : base(s => s.UserId == userId && s.Status == SubscriptionStatus.Active && s.StripePriceId == priceId)
        {
            
        }
    }
}
