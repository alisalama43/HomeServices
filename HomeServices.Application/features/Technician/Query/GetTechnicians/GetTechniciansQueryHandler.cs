using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Dtos;
using HomeServices.Domain.Entites.Technicians;
using HomeServices.Application.Features.Customers.Mappers;
using HomeServices.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Query.GetTechnicians
{
    public class GetTechniciansQueryHandler(IAppDbContext _context) : IRequestHandler<GetTechniciansQuery, Result<List<TechnicianDto>>>
    {
     

        async Task<Result<List<TechnicianDto>>> IRequestHandler<GetTechniciansQuery, Result<List<TechnicianDto>>>.Handle(GetTechniciansQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.TechnicianProfiles.Include(e => e.Reviews).AsNoTracking().ToListAsync();
            if (!customers.Any())
                return TechnicianError.NotFound;
            return customers.ToDtos();

        }
    }
}
