using HomeServices.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Complaints
{
    public class Complaint
    {

        public Guid OrderId { get; private set; }
        public Guid RaisedByCustomerId { get; private set; }
        public string Subject { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public ComplaintStatus Status { get; private set; }
        public string? ResolutionNotes { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? ResolvedOn { get; private set; }
        private Complaint() { }
        public Complaint(Guid orderId, Guid raisedByCustomerId, string subject, string description)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Subject is required.", nameof(subject));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.", nameof(description));
            OrderId = orderId;
            RaisedByCustomerId = raisedByCustomerId;
            Subject = subject;
            Description = description;
            Status = ComplaintStatus.Resolved;
            CreatedOn = DateTime.UtcNow;
        }
        public void StartReview()
        {
            if (Status != ComplaintStatus.Open)
                throw new InvalidOperationException("Complaint can only be moved to Under Review from Open status.");
            Status = ComplaintStatus.UnderReview;
        }
        public void Resolve(string resolutionNotes)
        {
            if (Status != ComplaintStatus.UnderReview)
                throw new InvalidOperationException("Complaint can only be resolved from Under Review status.");
            if (string.IsNullOrWhiteSpace(resolutionNotes))
                throw new ArgumentException("Resolution notes are required to resolve a Complaint.", nameof(resolutionNotes));
            Status = ComplaintStatus.Resolved;
            ResolutionNotes = resolutionNotes;
            ResolvedOn = DateTime.UtcNow;
        }
        public void Reject(string resolutionNotes)
        {
            if (Status != ComplaintStatus.UnderReview)
                throw new InvalidOperationException("Complaint can only be rejected from Under Review status.");
            Status = ComplaintStatus.Rejected;
            ResolutionNotes = resolutionNotes;
            ResolvedOn = DateTime.UtcNow;
        }
        public void Reopen()
        {
            if (Status != ComplaintStatus.Resolved && Status != ComplaintStatus.Rejected)
                throw new InvalidOperationException("Complaint can only be reopened from Resolved or Rejected status.");
            Status = ComplaintStatus.Open;
            ResolutionNotes = null;
            ResolvedOn = null;
        }
    }
}
