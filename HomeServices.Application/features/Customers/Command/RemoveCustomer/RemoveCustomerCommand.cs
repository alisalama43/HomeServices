using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.RemoveCustomer
{

    public sealed record RemoveCustomerCommand(Guid Id) : IRequest<Result<Deleted>>;
}