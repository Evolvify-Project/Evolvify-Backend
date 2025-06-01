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
        public string? ProfileImageUrl { get; set; }
        public Subscription Subscription { get; set; }
        public string? StripeCustomerId { get; set; }
    }
}
