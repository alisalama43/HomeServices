using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Domain.Entites.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Mappers
{
    public static class CustomerMapper
    {

        public static CustomerDto ToDto(this Customer entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            return new CustomerDto
            {
               
                Name = entity.Name!,
                Email = entity.Email!,
                Phone = entity.Phone!,
                Address = entity.Address!,
            };
        }

        public static List<CustomerDto> ToDtos(this IEnumerable<Customer> entities)
        {
            return [.. entities.Select(e => e.ToDto())];
            
            
        }



       




    }
}

