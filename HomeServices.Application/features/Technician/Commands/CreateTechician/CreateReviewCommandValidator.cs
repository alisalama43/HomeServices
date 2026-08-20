using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.CreateTechician
{
    public class CreateReviewCommandValidator:AbstractValidator<CreatReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(r => r.Rating).NotEmpty().WithMessage("Rating is Required");
            RuleFor(r => r.Rating).LessThan(6).GreaterThan(0).WithMessage("Rate from 1 : 5 ");
            RuleFor(r => r.CustomerId).NotEmpty();
                
                
        }
    }
}
