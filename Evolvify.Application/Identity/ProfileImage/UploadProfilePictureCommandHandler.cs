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
using static System.Net.Mime.MediaTypeNames;

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

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile-images");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.ImageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            
            string imageUrl = $"/profile-images/{fileName}";

            user.ProfileImage = imageUrl;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

    }
}
