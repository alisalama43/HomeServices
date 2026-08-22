using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.features.Services.Dto
{
    public class ServiceDto
    {
        public string? name { get; set; }
        public string? description { get; set; }
       public  IReadOnlyCollection<Guid>? RequiredProfessionIds;
    }
}
