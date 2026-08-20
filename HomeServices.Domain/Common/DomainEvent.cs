using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Common
{

    public sealed record ServiceRequestCreatedEvent(Guid ServiceRequestId, Guid CustomerId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OfferSubmittedEvent(Guid OfferId, Guid ServiceRequestId, Guid TechnicianId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OfferAcceptedEvent(Guid OfferId, Guid ServiceRequestId, Guid TechnicianId, Guid CustomerId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OrderCreatedEvent(Guid OrderId, Guid ServiceRequestId, Guid OfferId, Guid CustomerId, Guid TechnicianId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OrderConfirmedEvent(Guid OrderId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OrderStartedEvent(Guid OrderId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OrderCompletedEvent(Guid OrderId, Guid CustomerId, Guid TechnicianId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record OrderCancelledEvent(Guid OrderId, string Reason) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record PaymentCompletedEvent(Guid PaymentId, Guid OrderId, decimal Amount) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record ReviewSubmittedEvent(Guid ReviewId, Guid OrderId, Guid TechnicianId, int Rating) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

    public sealed record ComplaintCreatedEvent(Guid ComplaintId, Guid OrderId, Guid RaisedByCustomerId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

}
