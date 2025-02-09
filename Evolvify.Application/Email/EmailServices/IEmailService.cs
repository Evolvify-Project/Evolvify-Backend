using Evolvify.Application.Email.EmailSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Email.EmailServices
{
    public interface IEmailService
    {
        Task SendEmail(MailRequest mailRequest);
        Task SendEmailConfirmed(string email, string token);
    } 
}
