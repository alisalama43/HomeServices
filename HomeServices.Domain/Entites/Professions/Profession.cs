using HomeServices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Professions
{
    public class Profession : AuditableEntity
    {
        public string Name { get; private set; } = null!;

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Profession name is required.", nameof(name));

            Name = name;
        }
        protected Profession() { }
        protected Profession(Guid id, string name) : base(id)
        {
            Rename(name);
           
        }
    }
}
