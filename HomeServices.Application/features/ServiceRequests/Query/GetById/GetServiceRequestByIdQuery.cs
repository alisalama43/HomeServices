using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequest.Query.GetById
{
    public sealed record GetServiceRequestByIdQuery(Guid Id) : IRequest<Result<ServiceRequestDto>>;
}
