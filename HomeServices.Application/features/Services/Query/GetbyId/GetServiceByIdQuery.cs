using HomeServices.Application.features.Services.Dto;
using HomeServices.Domain.Common.ResultPattern.Abstraction;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Query.GetbyId
{
    public sealed record GetServiceByIdQuery(Guid Id) : IRequest<Result<ServiceDto>>;
   
}
