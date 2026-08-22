using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequest.Query.GetById
{
    internal class GetServiceRequestByIdQueryValidator:AbstractValidator<GetServiceRequestByIdQuery>
    {
        public GetServiceRequestByIdQueryValidator()
        {
            RuleFor(sr => sr.Id).NotEmpty();
              
        }
    }
}
