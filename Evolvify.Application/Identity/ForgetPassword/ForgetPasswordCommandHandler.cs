using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Email.EmailSettings;
using Evolvify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ForgetPassword
{
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailService emailService;

        public ForgetPasswordCommandHandler(UserManager<ApplicationUser> userManager,IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }
        public async Task<ApiResponse<bool>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user= await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResponse<bool>(false,StatusCodes.Status404NotFound,"Invalid user");
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var mail = new MailRequest()
            {
                Subject = "Reset Password",
                MailTo= user.Email,
                Body = $"{token}"
                
            };

            await emailService.SendEmail(mail);
            return new ApiResponse<bool>(true,StatusCodes.Status200OK,$"Reset password link sent to your email {token}");

        }
    }
}
