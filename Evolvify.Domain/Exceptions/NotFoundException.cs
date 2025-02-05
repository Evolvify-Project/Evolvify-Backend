using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Exceptions
{
    public class NotFoundException(string Entity,string id) : Exception($"{Entity} With Id => {id} is not found");
    
}
