using Evolvify.Application.Common.User;
using Evolvify.Application.DTOs.Response;
using Evolvify.Application.Email.EmailServices;
using Evolvify.Application.Identity.Register;
using Evolvify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ProfileImage
{
    public class UploadProfilePictureCommandHandler : IRequestHandler<UploadProfilePictureCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UploadProfilePictureCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(UploadProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null || request.ImageFile == null)
                return false;

            using (var memoryStream = new MemoryStream())
            {
                await request.ImageFile.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                user.ProfileImage =  Convert.ToBase64String(imageBytes);
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
