using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(x => x.name)
                 .NotEmpty()
                 .WithMessage("Name is required")
                 .MaximumLength(100)
                 .WithMessage("Name must not exceed 100 characters");

            RuleFor(x => x.email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.phone)
                .NotEmpty()
                .WithMessage("Phone is required")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Invalid Egyptian phone number");

            RuleFor(x => x.address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MaximumLength(250)
                .WithMessage("Address must not exceed 250 characters");
        }
    }
}
