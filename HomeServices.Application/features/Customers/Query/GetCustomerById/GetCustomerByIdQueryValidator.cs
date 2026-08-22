using FluentValidation;
using HomeServices.Application.features.Technician.Commands.RemoveTechnician;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Query.GetCustomerById
{
    public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
    {
       public GetCustomerByIdQueryValidator() 
        {
            RuleFor(c => c.id).NotEmpty().WithMessage("Id is empty"); 
        }
    }
}
