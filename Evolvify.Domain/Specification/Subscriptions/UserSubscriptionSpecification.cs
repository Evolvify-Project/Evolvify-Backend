using Evolvify.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Specification.Subscriptions
{
    public class UserSubscriptionSpecification:BaseSpecification<Subscription,int>
    {
        public UserSubscriptionSpecification(string userId):base(s=>s.UserId == userId)
        {
            
        }

    }
}
