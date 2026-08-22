using HomeServices.Application.features.Services.Dto;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Query.GetActiveService
{
    public sealed record GetActiveServiceQuery(bool isActive) : IRequest<List<ServiceDto>>;
    
}
