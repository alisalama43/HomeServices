using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Query.GetCustomerRequests
{
    public class GetCustomerRequestsQueryValidator:AbstractValidator<GetCustomerRequestsQuery>
    {
        public GetCustomerRequestsQueryValidator() 
        {
            RuleFor(r=>r.id).NotEmpty();   
        }
    }
}
