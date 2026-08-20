using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.RemoveCustomer
{
    public class RemoveCustomerCommandValidator:AbstractValidator<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidator() 
        {
            RuleFor(C => C.Id).NotEmpty().WithMessage("Identifier Is requried!!");
        }
    }
}
