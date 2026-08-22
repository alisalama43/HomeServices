using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Services.Dto;
using HomeServices.Application.features.Services.Mappers;
using HomeServices.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Query.GetActiveService
{
    public class GetActiveServiceQueryHandler(IAppDbContext context) : IRequestHandler<GetActiveServiceQuery, List<ServiceDto>>
    {
        public async Task<List<ServiceDto>> Handle(GetActiveServiceQuery request, CancellationToken cancellationToken)
        {
            var services = await context.Services.Where(e => e.IsActive == true).ToListAsync(cancellationToken);

            return services.ToDtos();
        }
    }
}
