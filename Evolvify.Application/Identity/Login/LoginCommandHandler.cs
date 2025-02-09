using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Token;
using Evolvify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<TokenResponse>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }
        public async Task<ApiResponse<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user=await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResponse<TokenResponse>(

                    success : false,
                    statusCode : 400,
                    message: "Invalid credentials",
                    errors : new List<string>() { "Email or password is incorrect" }
                );
                
            }
            var result=await signInManager.PasswordSignInAsync(user, request.Password, false,false);
            var confirmedEmail = await userManager.IsEmailConfirmedAsync(user);
            if (!confirmedEmail)
            {
                return new ApiResponse<TokenResponse>(false, 400, "Email not confirmed", null, new List<string> { "Email not confirmed" });
            }

            if (!result.Succeeded)
            {
                return new ApiResponse<TokenResponse>(false,400, "Invalid credentials", null, new List<string> { "Email or password is incorrect" });
            }
           

            var token = await tokenService.CreateToken(user, userManager);
            return new ApiResponse<TokenResponse>(true,200, "Login successful", token);



        }
    }
}
