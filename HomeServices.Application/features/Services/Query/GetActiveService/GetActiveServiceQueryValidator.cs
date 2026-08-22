using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Query.GetActiveService
{
    public class GetActiveServiceQueryValidator:AbstractValidator<GetActiveServiceQuery>
    {
        public GetActiveServiceQueryValidator() 
        {
            RuleFor(s => s.isActive).NotEmpty();
        }
    }
}
