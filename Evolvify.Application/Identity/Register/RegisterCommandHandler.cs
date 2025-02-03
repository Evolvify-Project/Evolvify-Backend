using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand,ApiResponse<string>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IValidator<RegisterCommand> validator;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager,IValidator<RegisterCommand> validator)
        {
            this.userManager = userManager;
            this.validator = validator;
        }
        public async Task<ApiResponse<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        { 
            var validationResult = await validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                return new ApiResponse<string>(
                    false
                    ,StatusCodes.Status400BadRequest
                    ,"Validation failed"
                    ,null
                    ,validationResult.Errors
                        .Select(e=>e.ErrorMessage).ToList()
                );
            }

            var existingUser= await userManager.FindByEmailAsync(request.Email);  
            if(existingUser!=null)
            {
                return new ApiResponse<string>(false,StatusCodes.Status400BadRequest,"Email already exists",null, new List<string> { "Email is already registered" });
            }

            var newUser = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(newUser, request.Password);

            if(!result.Succeeded)
            {
                return new ApiResponse<string>(false,StatusCodes.Status400BadRequest,"Failed to create user",null, result.Errors.Select(e=>e.Description).ToList());
            }

            return new ApiResponse<string>(true,StatusCodes.Status200OK,"User created successfully");


        }
    }
}
