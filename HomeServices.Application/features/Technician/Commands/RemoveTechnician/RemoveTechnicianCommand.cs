using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.RemoveTechnician
{
    public sealed record RemoveTechnicianCommand(Guid id) : IRequest<Result<Deleted>>;
    
}
