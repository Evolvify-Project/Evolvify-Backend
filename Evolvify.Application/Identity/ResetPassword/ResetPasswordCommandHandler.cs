using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ApiResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResponse<bool>(false, 404, "Invalid user");
            }
            if (request.Password != request.ConfirmPassword)
            {
                return new ApiResponse<bool>(false, 400, "Password and confirm password do not match");
            }
            
            var result = await userManager.ResetPasswordAsync(user, request.Code, request.Password);

            if(!result.Succeeded)
            {
                return new ApiResponse<bool>(false, 400, "Password reset failed", errors: result.Errors.Select(e => e.Description).ToList());
            }

            return new ApiResponse<bool>(true, 200, "Password reset successfully");
        }
    }
}
