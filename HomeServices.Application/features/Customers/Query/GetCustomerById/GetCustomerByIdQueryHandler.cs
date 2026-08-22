using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Customers.Mappers;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Query.GetCustomerById
{
    public class GetCustomerByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
    {
        private readonly IAppDbContext _appDbContext = context;
        public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var Customer=  _appDbContext.customers.FirstOrDefault(e=>e.Id==request.id);
            if (Customer == null)
                return CustomerError.NotFound;
            return Customer.ToDto();
                
        }
    }
}
