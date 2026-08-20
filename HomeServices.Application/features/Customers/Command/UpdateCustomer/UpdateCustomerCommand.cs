using MechanicShop.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(Guid id,string name ,string phone,string address) : IRequest<Result<Updated>>;
    
}
