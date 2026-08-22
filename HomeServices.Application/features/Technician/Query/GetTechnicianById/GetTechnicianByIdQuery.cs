using HomeServices.Application.features.Dtos;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Query.GetTechnicianById
{
    public sealed record GetTechnicianByIdQuery(Guid id) : IRequest<Result<TechnicianDto>>;
    
}
