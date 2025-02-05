using Evolvify.Application.Email.EmailSettings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Email.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings mailSettings;

        public EmailService(IOptions<MailSettings> options)
        {
            mailSettings=options.Value;
        }
        public async Task SendEmail(MailRequest mailRequest)
        {
            var emailMessage = new MimeMessage();

            MailboxAddress emailFrom=new MailboxAddress(mailSettings.DisplayName,mailSettings.Email);
            emailMessage.From.Add(emailFrom);

            MailboxAddress emailTo = new MailboxAddress(mailRequest.MailTo,mailRequest.MailTo);
            emailMessage.To.Add(emailTo);

            emailMessage.Subject=mailRequest.Subject;

            var emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody=mailRequest.Body;
            emailMessage.Body=emailBodyBuilder.ToMessageBody();

            using var smptp = new SmtpClient();
            smptp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smptp.Authenticate(mailSettings.Email, mailSettings.Password);
            await smptp.SendAsync(emailMessage);
            smptp.Disconnect(true);

        }
    }
}
