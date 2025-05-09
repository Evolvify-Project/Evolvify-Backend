using Evolvify.Application.Identity.UserProfile.Commands.UpdateProfileImage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.UserProfile.Commands.UpdateProfileImage
{
    public class UpdateProfileImageValidator: AbstractValidator<UpdateProfileImageCommand>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const long MaxSize = 2 * 1024 * 1024;

        public UpdateProfileImageValidator()
        {
           

            RuleFor(x => x.Image)
                .Must(F => _allowedExtensions.Contains(Path.GetExtension(F.FileName).ToLower()))
                .WithMessage("Image must be in jpg, jpeg or png format")
                .When(x => x.Image != null); 

            RuleFor(x => x.Image)
                .Must(F => F.Length <= MaxSize)
                .WithMessage("Image size must be less than 2MB")
                .When(x => x.Image != null); 
        }

    }
}
