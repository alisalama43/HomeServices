using HomeServices.Domain.Common;
using HomeServices.Domain.Common.ResultPattern;
using HomeServices.Domain.Entites.Complaints;
using HomeServices.Domain.Entites.Offers;
using HomeServices.Domain.Entites.Orders;
using HomeServices.Domain.Entites.Professions;
using MechanicShop.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Technicians
{
    public class Technician:AuditableEntity
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public bool IsActive { get; set; }
        public TechnicianProfession technicianProfession { get; set; }
        public Order order { get; set; }
        public Complaint complaint { get; set; }
        public Offer offer { get; set; }
        public readonly List<Review> reviews = [];
        public IEnumerable<Review> Reviews => reviews.AsReadOnly();
        private Technician()
        {
        }
        public Technician(Guid id,string name, string phone, string email, string bio,List<Review> reviewList): base(id)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Bio = bio;
            reviews = reviewList;
            
        }
        public static Result<Technician> Create(Guid id,string name, string phone, string email, string bio, List<Review> reviewList)
        {
            if (string.IsNullOrWhiteSpace(name))
                return TechnicianError.RequiredName;
            if (string.IsNullOrWhiteSpace(phone))
                return TechnicianError.RequiredPhone;
            if (string.IsNullOrWhiteSpace(email))
                return TechnicianError.RequiredEmail;
            if (string.IsNullOrWhiteSpace(bio))
                return TechnicianError.RequiredBio;
            return new Technician(id, name, phone, email, bio, reviewList);
       
        }   
        public  Result<Updated> Update(string name, string phone, string email, string bio)
        {
            if (string.IsNullOrWhiteSpace(name))
                return TechnicianError.RequiredName;
            if (string.IsNullOrWhiteSpace(phone))
                return TechnicianError.RequiredPhone;
            if (string.IsNullOrWhiteSpace(email))
                return TechnicianError.RequiredEmail;
            if (string.IsNullOrWhiteSpace(bio))
                return TechnicianError.RequiredBio;
            Name = name;
            Phone = phone;
            Email = email;
            Bio = bio;
            return Result.Updated;
        }
        public void Activate() => IsActive = true;
        public Result<Technician> SuspendedTechnician()
        {
            if (!IsActive)
                return Error.Validation("InactiveTechnician", "The technician is inactive.");
            return this;
        }

    }
}
