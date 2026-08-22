using HomeServices.Application.features.Customers.Dtos;
using HomeServices.Application.features.Customers.Mappers;
using HomeServices.Application.features.Services.Dto;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Entites.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Mappers
{
    public static class Servicemapper
    {
        public static ServiceDto ToDto (this Service entity)
        {
            return new ServiceDto
            {
               name= entity.Name,
               description= entity.Description,
                RequiredProfessionIds= entity.RequiredProfessionIds

            };
         
    }
        public static List<ServiceDto> ToDtos(this IEnumerable<Service> entities)
        {
            return [.. entities.Select(e => e.ToDto())];


        }
    }
}
