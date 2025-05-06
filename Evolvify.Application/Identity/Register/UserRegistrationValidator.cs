using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.Register
{
    public class UpdateProfileImageValidator: AbstractValidator<RegisterCommand>
    {
       
        public UpdateProfileImageValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password and Confirm Password do not match");
           
        }
    }
}
