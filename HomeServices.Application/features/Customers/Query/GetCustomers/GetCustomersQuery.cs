using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Query.GetCustomers
{
    public sealed record GetCustomersQuery : IRequest<Result<List<CustomerDto>>>;
   
}
