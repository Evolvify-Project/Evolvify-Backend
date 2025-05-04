using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces.ImageInterface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Commands.UpdateProfileImage
{
    public class UpdateProfileImageCommandHandler : IRequestHandler<UpdateProfileImageCommand,ApiResponse<string>>
    {
        private readonly IFileService _fileService;
        private readonly IUserContext _userContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateProfileImageCommandHandler(IFileService fileService, IUserContext userContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _fileService = fileService;
            _userContext = userContext;
        }
       
        async Task<ApiResponse<string>> IRequestHandler<UpdateProfileImageCommand, ApiResponse<string>>.Handle(UpdateProfileImageCommand request, CancellationToken cancellationToken)
        {
            var UserId = _userContext.GetCurrentUser().Id;

            var user = await _userManager.FindByIdAsync(UserId);

            if (request.Image==null)
            {
                return new ApiResponse<string>(false, StatusCodes.Status400BadRequest, "Image is Required");
            }

            var imageUrl = user.ProfileImageUrl;

            if (!string.IsNullOrEmpty(imageUrl))
            {
                _fileService.DeleteImage(imageUrl);
            }
            var imagePath = await _fileService.UploadImage(request.Image);
            user.ProfileImageUrl = imagePath;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user profile image");
            }               
           
            return new ApiResponse<string>(imagePath);
        }
    }
}
