using HomeServices.Application.Common.Abstract;
using HomeServices.Application.Common.Dtos;
using HomeServices.Application.features.Technician.Commands.CreateTechician;
using HomeServices.Domain.Entites.Technicians;
using MechanicShop.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Technician.Commands.UpdateTechnician
{
    public class UpdateTechnicianCommandHandler(
        ILogger<UpdateTechnicianCommandHandler> logger,
        IAppDbContext context,
        HybridCache cache)
        : IRequestHandler<UpdateTechnicianCommand, Result<Updated>>
    {

        private readonly ILogger _logger = logger;
        private readonly IAppDbContext _context = context;
        private readonly HybridCache _cache = cache;

        public async Task<Result<Updated>> Handle(UpdateTechnicianCommand request, CancellationToken cancellationToken)
        {
            var technician=await _context.TechnicianProfiles.FirstOrDefaultAsync(e=>e.Id==request.id,cancellationToken);
            if (technician==null)
            {
                _logger.LogWarning("Technician Not Found",request.id);
              return  TechnicianError.NotFound;
            }
            var updatedtech = technician.Update(request.name,
                                                request.phone,
                                                request.Email,
                                                request.bio);
            if (updatedtech.IsError)
            {
                return updatedtech.Errors;
            }
            await _context.SaveChangesAsync(cancellationToken);
            await _cache.RemoveByTagAsync("Technician", cancellationToken);
            _logger.LogInformation("User With Id : {} updated", request.id);
            return Result.Updated;

        }
    }
}
