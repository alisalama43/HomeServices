using HomeServices.Application.features.Profession.Dto;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Profession.Query
{
    public sealed record GetProfessionByIdQuery(Guid id) : IRequest<Result<ProfessionDto>>;
    
}
