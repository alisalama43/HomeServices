using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Customers.Dtos
{
    public class CustomerDto
    {
        public string? Name {  get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
