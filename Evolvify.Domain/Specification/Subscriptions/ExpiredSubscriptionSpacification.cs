using Evolvify.Domain.Entities.User;
using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Subscriptions
{
    public class ExpiredSubscriptionSpacification:BaseSpecification<Subscription,int>
    {
        public ExpiredSubscriptionSpacification():base(s => s.EndDate <= DateTime.Now && s.Status == SubscriptionStatus.Active)
        {
            
        }
    }
}
