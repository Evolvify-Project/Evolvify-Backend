using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Identity.UserProfile.DTOs;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Queries.ProfileImage
{
    public class GetUserProfileImageQueryHandler(IUserContext userContext,UserManager<ApplicationUser> userManager,IMapper mapper) : IRequestHandler<GetUserProfileImageQuery, ApiResponse<UserProfileImageDto>>
    {
        public async Task<ApiResponse<UserProfileImageDto>> Handle(GetUserProfileImageQuery request, CancellationToken cancellationToken)
        {
            var UserId=userContext.GetCurrentUser().Id;

            var User=await userManager.FindByIdAsync(UserId);

            if (User == null)
            {
                throw new NotFoundException("User not found"); 
            }
            
            var userProfileImage = mapper.Map<UserProfileImageDto>(User);
            return new ApiResponse<UserProfileImageDto>(userProfileImage);
            

        }
    }
}
