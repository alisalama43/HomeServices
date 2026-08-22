using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Query.GetTechnicianById
{
    public class GetTechnicianByIdQueryValidator:AbstractValidator<GetTechnicianByIdQuery>
    {
        public GetTechnicianByIdQueryValidator()
        {
            RuleFor(t=>t.id).NotEmpty();
        }
    }
}
