using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Technician.Commands.CreateTechician;
using HomeServices.Domain.Entites.Technicians;
using MechanicShop.Domain.Common.Results;
using MediatR;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Application.features.Customers.Mappers;

namespace HomeServices.Application.features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler(
        ILogger<CreateCustomerCommandHandler> logger,
        IAppDbContext context,
        HybridCache cache) : IRequestHandler<CreateCustomerCommand, Result<CustomerDto>>
    {
        private readonly ILogger _logger=logger;
        private readonly IAppDbContext _appDbContext = context;
        private readonly HybridCache _hybridCache = cache;

        public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var email = request.email.Trim().ToLowerInvariant();

            bool existed = await context.customers
                .AnyAsync(c => c.Email == email, cancellationToken);

            if (existed)
            {
                logger.LogWarning("Email already exists.");
                return CustomerError.ExistedEmail;
            }
            var Create = Customer.Create(Guid.NewGuid(), request.name, request.email,request.address, request.phone);
            if (Create.IsError)
            {
                return Create.Errors;
            }
            await _appDbContext.SaveChangesAsync(cancellationToken);
            await _hybridCache.RemoveByTagAsync("Customer", cancellationToken);
            var value=Create.Value;
            _logger.LogInformation("Custoomer {} Created",value.Id);
            return value.ToDto();
            
        }
    }
}
