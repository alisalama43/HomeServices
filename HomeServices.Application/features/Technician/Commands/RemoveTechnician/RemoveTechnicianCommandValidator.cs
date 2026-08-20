using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.RemoveTechnician
{
    public class RemoveTechnicianCommandValidator : AbstractValidator<RemoveTechnicianCommand>
    {
        public RemoveTechnicianCommandValidator()
        {
            RuleFor(e => e.id).NotEmpty().
                WithMessage("Custome Id Is required");
        }

    }
}