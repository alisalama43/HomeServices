using HomeServices.Domain.Entites.Complaints;
using HomeServices.Domain.Entites.Customer;
using HomeServices.Domain.Entites.Offers;
using HomeServices.Domain.Entites.Orders;
using HomeServices.Domain.Entites.Professions;
using HomeServices.Domain.Entites.Service;
using HomeServices.Domain.Entites.Technicians;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeServices.Application.Common.Abstract
{
    public interface IAppDbContext
    {
       

        DbSet<Domain.Entites.Technicians.Technician> TechnicianProfiles { get; }
        DbSet<Customer> customers { get; }

        DbSet<Profession> Professions { get; }

        DbSet<Service> Services { get; }

        DbSet<ServiceRequest> ServiceRequests { get; }

        DbSet<Offer> Offers { get; }

        DbSet<Order> Orders { get; }

        DbSet<Review> Reviews { get; }

        DbSet<Complaint> Complaints { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken);
    }
}
