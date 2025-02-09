using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand,ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ApiResponse<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user= await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new ApiResponse<bool>(false, StatusCodes.Status404NotFound, "Invalid user");

            var result=await userManager.ConfirmEmailAsync(user,request.Token);

            if (!result.Succeeded)
                return new ApiResponse<bool>(false, StatusCodes.Status400BadRequest, "Email confirmation failed");

            return new ApiResponse<bool>(true,StatusCodes.Status200OK, "Email confirmed successfully");

        }
    }
}
