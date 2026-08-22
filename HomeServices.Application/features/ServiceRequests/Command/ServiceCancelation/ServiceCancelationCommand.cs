using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Command.ServiceCancelation
{
    public sealed record ServiceCancelationCommand(Guid id) : IRequest<Result<Updated>>;
    
}
