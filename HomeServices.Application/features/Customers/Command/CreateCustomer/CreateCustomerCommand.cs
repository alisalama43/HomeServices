using HomeServices.Application.features.Customers.Dtos;
using MechanicShop.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.CreateCustomer
{
    public sealed record CreateCustomerCommand(string name,string email,string phone,string address) : IRequest<Result<CustomerDto>>;
    
}
