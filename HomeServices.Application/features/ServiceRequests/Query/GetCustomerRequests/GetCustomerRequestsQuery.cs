using HomeServices.Application.features.ServiceRequest.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Query.GetCustomerRequests
{
    public sealed record GetCustomerRequestsQuery(Guid id) : IRequest<List<ServiceRequestDto>>;
    
}
