using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Command.CreateServiceRequest
{
    public sealed class CreateServiceRequestCommandValidator
        : AbstractValidator<CreateServiceRequestCommand>
    {
        public CreateServiceRequestCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer is required.");

            RuleFor(x => x.ServiceId)
                .NotEmpty()
                .WithMessage("Service is required.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.Aaddress)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(500)
                .WithMessage("Address cannot exceed 500 characters.");

            RuleFor(x => x.PreferredDateTime)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Preferred date/time must be in the future.");

            RuleFor(x => x.RequiredProfessionIds)
                .NotNull()
                .WithMessage("Required professions are required.")
                .Must(x => x.Count > 0)
                .WithMessage("At least one profession is required.");

            RuleFor(x => x.RequiredProfessionIds)
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("Duplicate profession IDs are not allowed.");

            RuleForEach(x => x.RequiredProfessionIds)
                .NotEmpty()
                .WithMessage("Profession ID cannot be empty.");

            RuleFor(x => x.ImageReferences)
                .NotNull()
                .WithMessage("Image references are required.");

            RuleForEach(x => x.ImageReferences)
                .NotEmpty()
                .WithMessage("Image reference cannot be empty.")
                .MaximumLength(500)
                .WithMessage("Image reference cannot exceed 500 characters.");
        }
    }
}
