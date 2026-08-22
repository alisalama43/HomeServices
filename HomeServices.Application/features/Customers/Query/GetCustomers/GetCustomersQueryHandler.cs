using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Customers.Mappers;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

using System.Text;
using System.Xml;

namespace HomeServices.Application.features.Customers.Query.GetCustomers
{
    public class GetCustomersQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomersQuery, Result<List<CustomerDto>>>
    {
        private readonly IAppDbContext _appDbContext = context;

        public async Task<Result<List<CustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var Customers = await _appDbContext.customers.ToListAsync();
            if (Customers == null)
            {
                return CustomerError.NotFound;
            }
            return Customers.ToDtos();
        }
    }
}
