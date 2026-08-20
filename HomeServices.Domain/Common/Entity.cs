using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


        protected Entity()
        {
            
        }
        protected Entity(Guid id)
        {
            id=Id== Guid.Empty ? Guid.NewGuid() : id;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();

    }
}
