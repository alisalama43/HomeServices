using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Customers.Mappers;
using HomeServices.Application.features.ServiceRequest.Dtos;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Entites.Service;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceR = HomeServices.Domain.Entites.Service.ServiceRequest;

namespace HomeServices.Application.features.ServiceRequests.Mappers
{
    public static class ServiceRequestMappers
    {
        public static ServiceRequestDto ToDto(this ServiceR entity)
        {
            return new ServiceRequestDto
            {
                Address = entity.Address,
                CustomerId=entity.CustomerId,
                ServiceId=entity.ServiceId,
                Status=entity.Status,
                Description=entity.Description,
                AcceptedOfferId=entity.AcceptedOfferId,
                PreferredDateTime=entity.PreferredDateTime,

            };
        
    }
        public static List<ServiceRequestDto> ToDtos(this IEnumerable<ServiceR> entities)
        {
            return [.. entities.Select(e => e.ToDto())];


        }
    }
}
