using HomeServices.Domain.Common;
using HomeServices.Domain.Entites.Complaints;
using HomeServices.Domain.Entites.Orders;
using HomeServices.Domain.Entites.Service;
using HomeServices.Domain.Entites.Technicians;

using MechanicShop.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Domain.Entites.Customer
{
    public class Customer : AuditableEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public String Address { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public ServiceRequest serviceRequest { get; set; }
        public Order order { get; set; }
        public Complaint complaint { get; set; }
        private Customer()
        {
        }
        private Customer(Guid id, string name, string email, string address, string phone) : base(id)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            IsActive = true;
        }
        public static Result<Customer> Create(Guid id, string name, string email, string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                return CustomerError.RequiredName;
            if (string.IsNullOrWhiteSpace(email))
                return CustomerError.RequiredEmail;
           
            if (string.IsNullOrWhiteSpace(phone))
                return CustomerError.RequiredPhone;
            return new Customer(id, name, email, address, phone);
        }
        public Result<Updated> Update(string name, string email, string address, string phone, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))
                return CustomerError.RequiredName;
            if (string.IsNullOrWhiteSpace(email))
                return CustomerError.RequiredEmail;
           
            if (string.IsNullOrWhiteSpace(phone))
                return CustomerError.RequiredPhone;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            IsActive = isActive;
            return Result.Updated;
        }
        public void Activate() => IsActive = true;


        public Result<Customer> EnsureIsActive()
        {
            if (!IsActive)
                return CustomerError.RequiredActiveStatus;
            return this;
        }
    }
}
    
    
    
    