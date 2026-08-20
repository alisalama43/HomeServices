using HomeServices.Domain.Common;
using MechanicShop.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Service
{
    public class Service : AuditableEntity
    {
      
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        private Service() { }
        public Service(Guid id, string name, string description, bool isActive) : base(id)
        {
           
            Name = name;
            Description = description;
            IsActive = isActive;
        }
        public static Result<Service> Create(Guid id, string name, string description, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))
                return ServiceError.RequiredName;
            if (string.IsNullOrWhiteSpace(description))
                return ServiceError.RequiredDescription;
            return new Service(id, name, description, isActive);
        }
        public Result<Updated> Update(string name, string description, bool isActive)
        {
        
            IsActive = isActive;
            return Result.Updated;
        }
        public void Activate() => IsActive = true;
        public void EnsureIsActive()
        {
            if (!IsActive)
                throw new InvalidOperationException("Service is not active.");
        }
    }
}
