using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Exceptions
{
    public class ForbiddenException:Exception
    {
        public ForbiddenException(string operation,string target) : base($"You are not allowed to {operation} this {target}.")
        {
        }

    }
}
