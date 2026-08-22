using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Technician.Commands.CreateTechician;
using HomeServices.Domain.Common.Results;
using HomeServices.Domain.Entites.Technicians;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.RemoveTechnician
{
    public class RemoveTechnicianCommandhandler(
        ILogger<CreateTechnicianCommandHandeler> logger,
        IAppDbContext context,
        HybridCache cache) : IRequestHandler<RemoveTechnicianCommand, Result<Deleted>>
    {
        private readonly ILogger _logger =logger;
        private readonly IAppDbContext _context=context;
        private readonly HybridCache _cache=cache;
        public async Task<Result<Deleted>> Handle(RemoveTechnicianCommand request, CancellationToken cancellationToken)
        {
            var technician = await _context.TechnicianProfiles.FindAsync(request.id);
            if (technician == null) 
            {
                _logger.LogWarning("Technician With Id {} Not Found", request.id);
                return TechnicianError.NotFound;
            }
            var Reviews= _context.Reviews.Where(e=>e.TechnicianId==request.id).ToList();
      
            _context.Reviews.RemoveRange(Reviews);
            _context.TechnicianProfiles.Remove(technician);
            await _context.SaveChangesAsync(cancellationToken);
            await _cache.RemoveByTagAsync("Technician", cancellationToken);
            _logger.LogInformation("Technician{id} Deleted", request.id);
            return Result.Deleted;


        }
    }
}
