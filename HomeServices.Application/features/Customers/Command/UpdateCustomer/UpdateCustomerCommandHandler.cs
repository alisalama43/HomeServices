using HomeServices.Application.Common.Abstract;
using MechanicShop.Domain.Common.Results;
using MediatR;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Command.UpdateCustomer
{
    internal class UpdateCustomerCommandHandler
        (Logger<UpdateCustomerCommandHandler> looger,
        IAppDbContext context,
        HybridCache cache
        ) : IRequestHandler<UpdateCustomerCommand, Result<Updated>>
    {
        public Task<Result<Updated>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
