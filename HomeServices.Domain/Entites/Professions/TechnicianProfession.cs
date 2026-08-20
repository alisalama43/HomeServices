using HomeServices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Professions
{
    public class TechnicianProfession:AuditableEntity
    {
        public Guid TechnicianId { get; private set; }
        public Guid ProfessionId { get; private set; }
        public TechnicianProfession(Guid id, Guid technicianId, Guid professionId) : base(id)
        {

            TechnicianId = technicianId;
            ProfessionId = professionId;
        }
    }
}
