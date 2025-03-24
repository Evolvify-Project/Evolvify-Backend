using Evolvify.Application.Email.EmailSettings;
using Evolvify.Domain.AppSettings;
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

            if(mailRequest.attachment != null)
            {
                byte[] fileBytes;
                foreach(var file in mailRequest.attachment)
                {
                    if (file.Length > 0)
                    {
                        using var ms=new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes=ms.ToArray();
                        emailBodyBuilder.Attachments.Add(file.FileName, fileBytes,ContentType.Parse(file.ContentType));
                    }
                }
            }
            emailBodyBuilder.HtmlBody=mailRequest.Body;
            emailMessage.Body=emailBodyBuilder.ToMessageBody();

            using var smptp = new SmtpClient();
            smptp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smptp.Authenticate(mailSettings.Email, mailSettings.Password);
            await smptp.SendAsync(emailMessage);
            smptp.Disconnect(true);

         }

        public async Task SendEmailConfirmed(string email, string token)
        {
            var emailRequest = new MailRequest
            {
                Subject = "Confirm your email",
                Body= "Thank you for registering with us. Please use This OTP to complete your registration process: "+token,
                MailTo = email
            };
            await SendEmail(emailRequest);
        }



    }
}
