using Evolvify.Application.Common.User;
using Evolvify.Domain.Entities;
using Evolvify.Domain.Interfaces.ImageInterface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IFileService _fileService;
        private readonly IUserContext _userContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateUserCommandHandler(IFileService fileService, IUserContext userContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _fileService = fileService;
            _userContext = userContext;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var UserId = _userContext.GetCurrentUser().Id;

            var user = await _userManager.FindByIdAsync(UserId);

            if (request.Image != null)
            {
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



            }
        }

    }
}
