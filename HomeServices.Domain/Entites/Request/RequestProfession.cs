using HomeServices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Request
{
    public class RequestProfession: AuditableEntity
    {
        public Guid RequestId { get;  set; }
        public Guid ProfessionId { get;  set; }
        public RequestProfession(Guid id, Guid requestId, Guid professionId) : base(id)
        {
            RequestId = requestId;
            ProfessionId = professionId;
        }
    
    }
}
