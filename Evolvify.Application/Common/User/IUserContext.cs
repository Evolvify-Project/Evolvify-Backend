using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Common.User
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }
}
