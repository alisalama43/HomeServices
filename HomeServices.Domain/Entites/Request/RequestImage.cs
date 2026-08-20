using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Request
{
    public class RequestImage
    {
        private RequestImage() { }
        public RequestImage(Guid id, Guid requestId, string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new ArgumentException("Image URL is required.", nameof(imageUrl));
            Id = id;
            RequestId = requestId;
            ImageUrl = imageUrl;
        }
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string ImageUrl { get; set; }
    }
}
