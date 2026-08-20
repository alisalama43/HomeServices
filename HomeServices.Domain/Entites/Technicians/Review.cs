
using MechanicShop.Domain.Common.Results;

namespace HomeServices.Domain.Entites.Technicians
{
    public sealed class Review
    {
        public Guid Id { get;  set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public Guid TechnicianId { get; set; }
        public Guid CustomerId { get; set; }
        public Technician Technician { get; set; }
        private Review() { }
        public Review(Guid id, string? comment, int rating, Guid technicianId, Guid customerId)
        {
            Id = id;
            Comment = comment;
            Rating = rating;
            TechnicianId = technicianId;
            CustomerId = customerId;
           
        }
        public static Result<Review> create(Guid id, string comment ,int reating,Guid technicianId ,Guid Customerid) 
        {
            return new Review(id, comment, reating, technicianId, Customerid);
        }
    }
 
}

