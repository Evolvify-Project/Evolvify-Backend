using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.Identity.ConfirmEmail
{
    public class ConfirmEmailCommandValidator:AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.Email)
             .NotEmpty().WithMessage("Email is required.")
             .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
