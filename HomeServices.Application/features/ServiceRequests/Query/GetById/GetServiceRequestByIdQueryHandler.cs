using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Application.features.ServiceRequests.Mappers;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequest.Query.GetById
{
    internal class GetServiceRequestByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetServiceRequestByIdQuery, Result<ServiceRequestDto>>
    {
        public async Task<Result<ServiceRequestDto>> Handle(GetServiceRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var servicerequest= await context.ServiceRequests.FirstOrDefaultAsync(e=>e.Id==request.Id);
            if (servicerequest == null)
                return ServiceError.NotFound;
          return  servicerequest.ToDto();
           
        }
    }
}
