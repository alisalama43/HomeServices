using HomeServices.Application.Common.Dtos;
using MechanicShop.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.UpdateTechnician
{
    public sealed record UpdateTechnicianCommand(Guid id,string name,string Email,string phone ,string bio) : IRequest<Result<Updated>>;
    
}
