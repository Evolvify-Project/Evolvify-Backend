using Evolvify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.AppSettings
{
    public class SeedUsers
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public PlanType PlanType { get; set; }
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(1);

    }

    public class SeedUsersSettings
    {
        public List<SeedUsers> SeedUsers { get; set; }
    }

}
