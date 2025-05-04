using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Community
{
    public abstract class Like: BaseEntity<Guid>
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
