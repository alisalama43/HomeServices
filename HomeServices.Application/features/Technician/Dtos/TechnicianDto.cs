using HomeServices.Domain.Entites.Technicians;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Dtos
{
    public class TechnicianDto
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public List<ReviewDto> reviews { get; set; }
    }
    public sealed record ReviewDto(Guid id, string Comment, int rating, Guid TechId, Guid CustomerId);
   
}
