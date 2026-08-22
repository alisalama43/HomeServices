using HomeServices.Domain.Entites.Request;
using HomeServices.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.ServiceRequest.Dtos
{
    public class ServiceRequestDto
    {

        private readonly List<RequestProfession> _requiredProfessions = new();
        private readonly List<RequestImage> _images = new();

        public Guid CustomerId { get;  set; }
        public Guid ServiceId { get;  set; }
        public string Description { get;  set; } = string.Empty;
        public string Address { get;  set; } = null!;
        public DateTime PreferredDateTime { get;  set; }
        public ServiceRequestStatus Status { get;  set; }
        public Guid? AcceptedOfferId { get;  set; }
    }
}
