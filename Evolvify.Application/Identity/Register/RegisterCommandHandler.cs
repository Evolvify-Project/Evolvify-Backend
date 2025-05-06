using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Domain.Constants;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using Evolvify.Domain.Interfaces.ImageInterface;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand,ApiResponse<string>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailService emailService;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager,IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }
        public async Task<ApiResponse<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        { 
           
            var existingUser= await userManager.FindByEmailAsync(request.Email);  
            if(existingUser!=null)
            {
                return new ApiResponse<string>(false,StatusCodes.Status400BadRequest,"Email already exists",null, new List<string> { "Email is already registered" });
            }

            var newUser = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };


            var result = await userManager.CreateAsync(newUser, request.Password);

            var roleResult = await userManager.AddToRoleAsync(newUser, UserRole.User);

            if(!result.Succeeded)
            {
                return new ApiResponse<string>(false,StatusCodes.Status400BadRequest,"Failed to create user",null, result.Errors.Select(e=>e.Description).ToList());
            }

           
            //var code=await userManager.GenerateEmailConfirmationTokenAsync(newUser);

              //await emailService.SendEmailConfirmed(newUser.Email, code);

            //return new ApiResponse<string>(true,StatusCodes.Status200OK, "User registered successfully.Please check your email to confirm your account.");

            return new ApiResponse<string>(true,StatusCodes.Status200OK, $"User registered successfully.");


        }
    }
}
