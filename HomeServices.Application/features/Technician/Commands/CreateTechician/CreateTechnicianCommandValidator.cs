using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.CreateTechician
{
    public class CreateTechnicianCommandValidator:AbstractValidator<CreateTechnicianCommand>
    {
        public CreateTechnicianCommandValidator()
        {
            RuleFor(x => x.name)
           .NotEmpty().WithMessage("Name is required")
           .MaximumLength(100);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email")
                .Must(email => email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Email must be a Gmail address")
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Phone number must be a valid Egyptian mobile number.");
             RuleFor(x => x.bio)
                .NotEmpty().WithMessage("Bio Required")
                .MinimumLength(100).WithMessage("Minimam length is 100");
                             


        }
    }
}
