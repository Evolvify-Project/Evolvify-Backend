using AutoMapper;
using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Identity.UserProfile.DTOs;
using Evolvify.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Queries.UserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, ApiResponse<UserProfileDto>>
    {
        private readonly IUserContext _userContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public GetUserProfileQueryHandler(IUserContext userContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userContext = userContext;
            _userManager = userManager;
        }
        public async Task<ApiResponse<UserProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var user = await _userManager.FindByIdAsync(userId);

            var userProfile = _mapper.Map<UserProfileDto>(user);

            return new ApiResponse<UserProfileDto>(userProfile);


        }
    }

}
