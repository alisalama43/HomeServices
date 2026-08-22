using HomeServices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Request
{
    public class RequestImage:AuditableEntity
    {

        public Guid ServiceRequestId { get; private set; }
        public string ImageReference { get; private set; } = null!;
        public string? Caption { get; private set; }
        public DateTime UploadedOn { get; private set; }

        private RequestImage() { }

        internal RequestImage(Guid id, Guid serviceRequestId, string imageReference, string? caption) : base(id)
        {
            if (string.IsNullOrWhiteSpace(imageReference))
                throw new ArgumentException("Image reference is required.", nameof(imageReference));

            ServiceRequestId = serviceRequestId;
            ImageReference = imageReference;
            Caption = caption;
            UploadedOn = DateTime.UtcNow;
        }
    }
}
