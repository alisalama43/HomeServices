using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Application.features.ServiceRequests.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequests.Query.GetCustomerRequests
{
    public class GetCustomerrequestsQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomerRequestsQuery, List<ServiceRequestDto>>
    {
        public async Task<List<ServiceRequestDto>> Handle(GetCustomerRequestsQuery request, CancellationToken cancellationToken)
        {
            var Customerrequests=await context.ServiceRequests.Where(Cr=>Cr.CustomerId==request.id).ToListAsync();
            return Customerrequests.ToDtos();
        }
    }
}
