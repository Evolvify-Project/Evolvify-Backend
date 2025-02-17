using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Entity, string id):base(($"{Entity} With Id => {id} is not found"))
        {
            
        }

        public NotFoundException(string message):base(message) 
        {
            
        }
    };
    
}
