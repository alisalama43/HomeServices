using HomeServices.Application.features.Dtos;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Query.GetTechnicians
{
    public sealed record GetTechniciansQuery : IRequest<Result<List<TechnicianDto>>>;
}
