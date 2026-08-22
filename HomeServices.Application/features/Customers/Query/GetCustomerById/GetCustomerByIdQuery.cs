using HomeServices.Application.Common.Abstract;
using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Domain.Common.Results;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Query.GetCustomerById
{
    public sealed record GetCustomerByIdQuery(Guid id) : ICachedQuery<Result<CustomerDto>>
    {
        public string CacheKey => "Customers";

        public string[] Tags => ["customer"];

        public TimeSpan Expiration => TimeSpan.FromMinutes(10);
    }
}
