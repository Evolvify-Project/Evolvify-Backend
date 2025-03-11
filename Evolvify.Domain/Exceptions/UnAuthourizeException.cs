using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Exceptions
{
    public class UnAuthourizeException : Exception
    {
        public UnAuthourizeException(string message) : base(message)
        {
        }
    
    }
}
