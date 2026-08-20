using HomeServices.Domain.Common;
using HomeServices.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Offers
{
    public class Offer : AuditableEntity
    {
        public Guid ServiceRequestId { get; private set; }
        public Guid TechnicianId { get; private set; }
        public decimal Price { get; private set; } 
        public string? Message { get; private set; }
        public TimeSpan EstimatedDuration { get; private set; }
        public OfferStatus Status { get; private set; }
        public DateTime SubmittedOn { get; private set; }
     private Offer() { }
        public Offer(Guid id, Guid serviceRequestId, Guid technicianId, decimal price, string? message, TimeSpan estimatedDuration):base(id)
        {
            Id = id;
            ServiceRequestId = serviceRequestId;
            TechnicianId = technicianId;
            Price = price;
            Message = message;
            EstimatedDuration = estimatedDuration;
            Status = OfferStatus.Pending;
            SubmittedOn = DateTime.UtcNow;
        }
       
       public void RaiseAcceptedEvent(Guid customerId)
         {
            AddDomainEvent(new OfferAcceptedEvent(Id, ServiceRequestId, TechnicianId, customerId));
         }
        
        public void Accept()
        {
         if (Status == OfferStatus.Rejected || Status == OfferStatus.Withdrawn)
            {
                throw new InvalidOperationException("Cannot accept a rejected or withdrawn offer.");
            }
            Status = OfferStatus.Accepted;
        }
        public void Reject()
        {
            Status = OfferStatus.Rejected;
        }
        public void Withdraw()
        {
            Status = OfferStatus.Withdrawn;
        }
        public bool Isactive => Status == OfferStatus.Pending || Status == OfferStatus.Accepted;
    }
}
