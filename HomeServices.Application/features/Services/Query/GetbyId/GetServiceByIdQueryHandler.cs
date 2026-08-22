using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Services.Dto;
using HomeServices.Application.features.Services.Mappers;
using HomeServices.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Query.GetbyId
{
    public class GetServiceByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetServiceByIdQuery, Result<ServiceDto>>
    {
        public async Task<Result<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service=await context.Services.FirstOrDefaultAsync(e=>e.Id==request.Id);
            return service.ToDto();
        }
    }
}
