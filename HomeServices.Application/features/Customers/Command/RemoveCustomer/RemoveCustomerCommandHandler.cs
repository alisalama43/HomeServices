using HomeServices.Application.Common.Abstract;
using HomeServices.Domain.Entites.Customer;
using MechanicShop.Domain.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HomeServices.Application.features.Customers.Command.RemoveCustomer
{
    public class RemoveCustomerCommandHandler(ILogger<RemoveCustomerCommandHandler> logger,
                                              HybridCache cache,
                                              IAppDbContext context) : IRequestHandler<RemoveCustomerCommand, Result<Deleted>>
    {
        private readonly ILogger _logger = logger;
        private readonly IAppDbContext _appDbContext = context;
        private readonly HybridCache _cache =cache;
       
        public async Task<Result<Deleted>> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            var ExisitingCustomer=context.customers.FirstOrDefault(c=>c.Id==request.Id);
            if (ExisitingCustomer == null)
            {
                _logger.LogInformation("Customer Not Exists");
                return CustomerError.NotFound;
            }

            _appDbContext.customers.Remove(ExisitingCustomer);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            await _cache.RemoveByTagAsync("customer", cancellationToken);

            _logger.LogInformation("Customer {CustomerId} deleted successfully.", request.Id);

            return Result.Deleted;
        }
    }
}

