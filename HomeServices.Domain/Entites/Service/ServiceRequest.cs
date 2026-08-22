using HomeServices.Domain.Common;
using HomeServices.Domain.Entites.Request;

using HomeServices.Domain.Enum;
using HomeServices.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Transactions;

namespace HomeServices.Domain.Entites.Service
{
    public class ServiceRequest : AuditableEntity
    {
        private readonly List<RequestProfession> _requiredProfessions = new();
        private readonly List<RequestImage> _images = new();

        public Guid CustomerId { get; private set; }
        public Guid ServiceId { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Address { get; private set; } = null!;
        public DateTime PreferredDateTime { get; private set; }
        public ServiceRequestStatus Status { get; private set; }
        public Guid? AcceptedOfferId { get; private set; }

        public IReadOnlyCollection<RequestProfession> RequiredProfessions => _requiredProfessions.AsReadOnly();
        public IReadOnlyCollection<RequestImage> Images => _images.AsReadOnly();
        public ServiceRequest(Guid id, Guid customerId, Guid serviceId, string description, string address, DateTime preferredDateTime, IEnumerable<Guid> requiredProfessionIds) : base(id)
        {
            if (customerId == Guid.Empty) throw new ArgumentException("CustomerId is required.", nameof(customerId));
            if (serviceId == Guid.Empty) throw new ArgumentException("ServiceId is required.", nameof(serviceId));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.", nameof(description));
            if (preferredDateTime <= DateTime.UtcNow)
                throw new ArgumentException("Preferred date/time must be in the future.", nameof(preferredDateTime));
            var professionIds = requiredProfessionIds?.Distinct().ToList() ?? new List<Guid>();
            if (!professionIds.Any())
                throw new ArgumentException("At least one required profession is needed.", nameof(requiredProfessionIds));
            Id = id;
            CustomerId = customerId;
            ServiceId = serviceId;
            Description = description;
            Address = address;
            PreferredDateTime = preferredDateTime;
            Status = ServiceRequestStatus.Draft;
            foreach (var professionId in professionIds)
            {
                _requiredProfessions.Add(new RequestProfession(Guid.NewGuid(), id, professionId));
            }
        }
        private ServiceRequest()
        { }

        
    public void AddImage(string imageReference, string? caption = null)
    {
        EnsureCanBeEdited();
        _images.Add(new RequestImage(Guid.NewGuid(), Id, imageReference, caption));
    }
        public Result<ServiceRequest> Cancel()
        {
            if (Status == ServiceRequestStatus.Completed)
                return ServiceError.CannotCancelCompletedRequest;

            if (Status == ServiceRequestStatus.Cancelled)
                return ServiceError.AlreadyCancelled;

            Status = ServiceRequestStatus.Cancelled;

            return this;
        }
        public Result<ServiceRequest> Submit()
        {
            if (Status != ServiceRequestStatus.Draft)
                return ServiceError.CannotSubmitNonDraftRequest;
            Status = ServiceRequestStatus.Pending;
            return this;
        }
        public Result<ServiceRequest> Matched()
        {
            if (Status != ServiceRequestStatus.Pending)
                return ServiceError.CannotMatchNonPendingRequest;
            Status = ServiceRequestStatus.Matched;
            return this;
        }
        public Result<ServiceRequest> AcceptOffer()
        {
            if (Status != ServiceRequestStatus.OffersReceived)
                return ServiceError.CannotAcceptOffer;

            Status = ServiceRequestStatus.Accepted;

            return this;
        }
        public void start()
        {
            Status = ServiceRequestStatus.InProgress;

        }
        public void complete()
        {
            Status = ServiceRequestStatus.Completed;
        }

        public bool CanReceiveOffers() =>
            Status is ServiceRequestStatus.Matched or ServiceRequestStatus.OffersReceived;
        public void EnsureCanBeEdited()
        {
            if (Status is ServiceRequestStatus.Cancelled or ServiceRequestStatus.Completed)
                throw new InvalidOperationException("Cannot edit a request that is cancelled or completed.");

        }

    }
}
