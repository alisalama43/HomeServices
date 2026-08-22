using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Dtos;
using HomeServices.Domain.Entites.Technicians;
using HomeServices.Application.Features.Customers.Mappers;
using HomeServices.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Query.GetTechnicianById
{
    public class GetTechnicianByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetTechnicianByIdQuery, Result<TechnicianDto>>
    {
        public async Task<Result<TechnicianDto>> Handle(GetTechnicianByIdQuery request, CancellationToken cancellationToken)
        {
            var Technician = await context.TechnicianProfiles.AsNoTracking().Include(e => e.Reviews).FirstOrDefaultAsync(t => t.Id == request.id);
            if (Technician == null)
                return TechnicianError.NotFound;
            return Technician.ToDto();
        }
    }
}
