using HomeServices.Application.Common.Abstract;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Command.ServiceCancelation
{
    public class ServiceCancelationCommandHandler(IAppDbContext context) : IRequestHandler<ServiceCancelationCommand, Result<Updated>>
    {
        public async Task<Result<Updated>> Handle(ServiceCancelationCommand request, CancellationToken cancellationToken)
        {
            var ServiceRequest =await context.ServiceRequests.FindAsync(request.id);
            if (ServiceRequest == null)
                return ServiceError.NotFound;
            ServiceRequest.Cancel();
            return Result.Updated;
        }
    }
}
